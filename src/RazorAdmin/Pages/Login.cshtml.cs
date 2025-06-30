using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace RazorAdmin.Pages;

public class LoginModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;

    [BindProperty]
    public string Username { get; set; } = string.Empty;

    [BindProperty]
    public string Password { get; set; } = string.Empty;

    public LoginModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.PostAsJsonAsync(
                "http://localhost:5135/api/auth/login",
                new { Username, Password });

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();

              
                HttpContext.Session.SetString("JWT", token);

               
                Response.Cookies.Append("jwt", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTimeOffset.Now.AddMinutes(30)
                });

                return RedirectToPage("/Admin/Dashboard");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt");
            return Page();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Login error: {ex}");
            ModelState.AddModelError(string.Empty, "Login failed");
            return Page();
        }
    }
}

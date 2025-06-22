@echo off
echo === TESTING REST API (port 5135) ===
echo.

echo [1] GET all products:
curl -X GET "http://localhost:5135/api/products" -H "accept: application/json"
echo.

set /p productId=Enter product ID to test: 

echo [2] GET product ID %productId%:
curl -X GET "http://localhost:5135/api/products/%productId%" -H "accept: application/json"
echo.

echo [3] UPDATE product ID %productId%:
curl -X PUT "http://localhost:5135/api/products/%productId%" ^
  -H "Content-Type: application/json" ^
  -d "{\"id\":%productId%,\"name\":\"Updated\",\"price\":99.99,\"description\":\"Updated\"}"
echo.

echo === TESTING GRAPHQL (port 5123) ===
echo [4] GraphQL query:
curl -X POST "http://localhost:5123/graphql" ^
  -H "Content-Type: application/json" ^
  -d "{\"query\":\"{ products { id name price } }\"}"
echo.

pause
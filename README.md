# Coolvision test project

### Inportant notes:
- The project don't have UI page.
- The configuration keys I got manually from web.config. Exist an auto builder of app.config object with all required data (section) from app.config file.
- Missing usage of InMemory or Redis caches.
- Missing async exception logs to DB and/or File.
- Added country name adaptation table. For example Skyscanner use Unated Kindom name but Covit API use UK name. The adaptation table need to be moved to configuration file.

### Usage:
- Get repository from GitHub
- Run using IIS or IIS Express, use browser or Postman for getting the response. Parse result json using online or other json parser.
- The https://localhost:44326/api/CoolvisionTest/{any date}/{any country} URL will return required in task data. The data will be ordered by "Departure date" field (asc).
- List of countries: "France,United Kingdom,United States,Australia". List need to be moved to configuration file (if static) or to user UI pickup.
>Request for any date and any country from list: https://localhost:44326/api/CoolvisionTest
Request for exact date and any country from list: https://localhost:44326/api/CoolvisionTest/2021-09-01
Request for exact date and country: https://localhost:44326/api/CoolvisionTest/2021-09-01/France

# Coolvision test project

### Inportant notes:
- The project don't have UI page.
- The configuration keys I got manually from web.config. Exist an auto builder of app.config object with all required data (section) from app.config file.
- Missing usage of InMemory or Redis caches.
- Missing async exception logs to DB and/or File.

### Usage:
- Get repository from GitHub
- Run using IIS or IIS Express, use browser or Postman for getting the response. Parse result json using online or other json parser.
- The https://localhost:44326/api/CoolvisionTest/{any country} URL will return required in task data. The data will be ordered by "Departure date" field (asc).
> Rejquest example: https://localhost:44326/api/CoolvisionTest/France
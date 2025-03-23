<h1>CarServiceSystem</h1>
------------------------------------------------------------------------------
<h2>Инструкция для бека:</h2>
выполнить docker compose up (разворачивает контейнер с БД MS SQl).
Применить миграции, чтобы создать таблицы, и заполнить их данными:
dotnet ef --project DAL database update  --context DelovieLiniiContext --startup-project WebApi
Бек запуститься по адресу: http://localhost:5180/

<h2>Инструкция для фронта:</h2>

перейти в директорию carclient
Выполнить npm install
Выполнить npm run dev
Фронт запуститься по адресу: http://localhost:5190/

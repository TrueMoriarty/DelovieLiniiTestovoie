<h1>CarServiceSystem</h1>
<h2>Инструкция для бека:</h2>
1. выполнить '''docker docker-compose up''' (разворачивает контейнер с БД MS SQl)
2. Применить миграции, чтобы создать таблицы, и заполнить их данными: ```dotnet ef --project DAL database update  --context DelovieLiniiContext --startup-project WebApi```

Бек запуститься по адресу: http://localhost:5180/

<h2>Инструкция для фронта:</h2>

1. перейти в директорию carclient
2. Выполнить npm install
3. Выполнить npm run dev

Фронт запуститься по адресу: http://localhost:5190/

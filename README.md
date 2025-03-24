# DelovieLiniiTestovoe

### Инструкция для бека:
1. выполнить ```docker docker-compose up``` (разворачивает контейнер с БД MS SQl)
2. Применить миграции, чтобы создать таблицы, и заполнить их данными: ```dotnet ef --project DAL database update  --context DelovieLiniiContext --startup-project WebApi```

Бек запуститься по адресу: http://localhost:5180/

### Инструкция для фронта:

1. перейти в директорию client
2. Выполнить npm install
3. Выполнить npm run dev

Фронт запуститься по адресу: http://localhost:5190/

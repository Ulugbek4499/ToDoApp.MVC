1. Change ConnectionString configurations like "UserId" and "Password" according to your Database. "ToDoApp.MVC.UI/appsettings.json"
2. Delete the migration located at "ToDoApp.Infrastructure/Persistence/Migrations."
3. In the Package Manager Console, select the "ToDoApp.Infrastructure" as the Default project.
4. Run the following command in the Package Manager Console: 'Add-Migration Initial -outputdir "Persistence/Migrations".'
5. Execute the following command in the Package Manager Console: 'Update-Database.'
6. Now you can run and test the application.

***Optional***
If you want to receive notifications from the Telegram Bot, you can modify the "chatId" and "botToken" settings. 
Otherwise, notifications will only be sent to my Telegram bot. These notifications will inform you about any exceptions that are thrown, 
providing detailed information to help analyze and troubleshoot any issues in your code after deployment. 
Additionally, when you create, update, or delete new objects, notifications will be sent to the Telegram bot.
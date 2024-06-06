[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12

#echo $args[0]

# Переменные для отправки в телегу
$botToken = "7463441241:AAGN2_tjL8aJctKQ8p1CfjKW61GkA48u7Kg"
$chatId = "-1002125306971"
$messageText = "Hello World from PowerShell"
$url="https://api.telegram.org/bot$botToken/sendMessage?chat_id=$chatID&text=$messageText"
Invoke-RestMethod -Uri $url -Method Post


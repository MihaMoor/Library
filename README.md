# Library

Эмуляция работы реальной библиотеки.

## Docker

После запуска `docker-compose` микросервисы будут доступны по следующим ссылкам:
+ Apache Kafka (kafka) - [localhost:25092](http://localhost:25092)
+ UI for Apache Kafka (kafka.ui) - [localhost:9000](http://localhost:9000)
+ Book API (book.api) - [localhost:8080](http://localhost:8080) ([swagger](http://localhost:8080/swagger/index.html))
+ Book DB:
	- Для использования внутри приложения: Host=book.db; Username=postgres; Password=bookpassword;
	- Для подключения через локальный PgAdmin: connection=localhost; port=5430; user=postgres; password=bookpassword;
+ Magazine API (magazine.api) - [localhost:8180](http://localhost:8180) ([swagger](http://localhost:8180/swagger/index.html))
+ User API (user.api) - [localhost:8280](http://localhost:8280) ([swagger](http://localhost:8280/swagger/index.html))
+ Client Shell (client.shell) - [localhost:8380](http://localhost:8380)

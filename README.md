# ProductService

## A RESTful Web-Interface für Produktverwaltung

## Struktur

Die Lösung besteht auf drei Projekte

###### ProductService.Api
4 Controllers mit Endpoints: Category, Categories, Product, Products
NSwag für Dokumentierung
Dependency-Injection für alle Implementations von Services
ApiActionFilter

###### ProductService.Application
Interfaces
Application-Logik, Implementierung von Interfaces, es ist trivial, aber es ermöglicht die Abstrahierung
Data Transfer Objects und Struktur von Befehle und Abfragen
Validierung durch FluentValidation

###### ProductService.Infrastructure
Implementierung von Repositories-Interfaces, die die Datenbank verwalten
Datenbank-Context

## Anweisungen zum Testen

Es gibt zwei Dateien: die Quellcode-Arhiv und das veröffentlichte Verzeichnis (ProductService)

Sie können in Visual Studio 2019 die Solution ProductService öffnen und starten.
StartUp-Projekt - ProductService.Api

Alnernativ können Sie die Console-Anwendung ProductService.Api.Exe aus dem Verzeichnis ausführen.
In Browser navigieren Sie zu http://localhost:5000/swagger (diese Einstellungen sind in launchSettings.json)

Die generierte OpenAPI Spezifikation kann man unter http://localhost:5000/swagger/v1/swagger.json finden, oder in spec.json

Connection String für die Datenbank befindet sich in appsettings.json

Der Quellcode wurde auf GitHub veröffentlicht https://github.com/dgrin3/ProductService
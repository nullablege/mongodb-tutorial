# .NET Core & MongoDB CRUD Tutorial

https://medium.com/@egenull0/net-coreda-mongodb-ye-giri%C5%9F-cc63615e0564

Bu proje, .NET Core ve MongoDB kullanarak temel CRUD (Create, Read, Update, Delete) işlemlerinin nasıl gerçekleştirileceğini gösteren bir başlangıç (101) rehberidir. Karmaşık mimari desenlerden (CQRS, Onion Arch. vb.) arındırılmış, doğrudan konuya odaklanan tek katmanlı bir MVC yapısındadır.

## 🚀 Proje Hakkında

Normal şartlarda Entity Framework Core ile ilişkisel veritabanları (SQL Server, PostgreSQL) kullanılırken, bu projede NoSQL bir veritabanı olan MongoDB'nin .NET ekosistemine entegrasyonu ele alınmıştır.

Proje şunları içerir:
* MongoDB Driver entegrasyonu.
* Dependency Injection (DI) ile MongoClient yönetimi.
* BSON mapping ve ObjectId kullanımı.
* Temel veri listeleme, ekleme, güncelleme ve silme işlemleri.
* Bootstrap ile hazırlanmış basit bir kullanıcı arayüzü.

## 🛠 Kullanılan Teknolojiler

* [.NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
* [MongoDB.Driver](https://www.nuget.org/packages/MongoDB.Driver)
* ASP.NET Core MVC
* Bootstrap 5

## ⚙️ Kurulum ve Çalıştırma

Projeyi yerel ortamınızda çalıştırmak için aşağıdaki adımları izleyin:

### 1. Gereksinimler
* Bilgisayarınızda [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) yüklü olmalıdır.
* [MongoDB Community Server](https://www.mongodb.com/try/download/community) veya Docker üzerinde çalışan bir MongoDB instance'ı gereklidir.
* Veritabanını görselleştirmek için [MongoDB Compass](https://www.mongodb.com/products/tools/compass) önerilir.

### 2. Veritabanı Ayarları
MongoDB Compass veya CLI kullanarak:
1.  `mongodb://localhost:27017` adresine bağlanın.
2.  `todo_db` adında bir veritabanı oluşturun.
3.  Bu veritabanı altında `todos` adında bir collection (tablo) oluşturun.

### 3. Konfigürasyon
`appsettings.json` dosyasındaki ayarların yerel MongoDB kurulumunuzla eşleştiğinden emin olun:

```json
{
  "MongoSettings": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "todo_db",
    "CollectionName": "todos"
  }
}


Görseller :
<img width="1919" height="986" alt="Screenshot_4" src="https://github.com/user-attachments/assets/34fbad06-919d-4933-9587-dc7a576a88d7" />
<img width="1911" height="987" alt="Screenshot_3" src="https://github.com/user-attachments/assets/67b33dc8-e68f-4771-b4c1-396888e48669" />
<img width="1916" height="990" alt="Screenshot_2" src="https://github.com/user-attachments/assets/ad46fcca-c65d-4dcb-8fe0-2831b3a6252c" />


  # .NET Core Developer - Bilinmesi Gereken Kütüphaneler Kursu                                                                
                                  
Bu repository, Fatih Çakıroğlu'nun  .NET Core Developer - Bilinmesi Gereken Kütüphaneler kursunu içeriğini göstermektedir. Bu kurs boyunca SOLID prensipleri üzerine odaklandık ve çeşitli kütüphaneleri kullanarak gerçek senaryolar üzerinde uygulamalar geliştirdik.
## Kurs Detayları                
                          
Bu kurs aşağıdaki konuları içermektedir:            
                 
- SOLID Prensipleri    
- Kullanılan Kütüphaneler   
- Hata Yönetimi ve Sayfaları  
- Loglama  
- Swagger ile Ayrıntılı Dökümantasyon
- Environment Ortamları
## Kullanılan Kütüphaneler ve Konu Başlıkları 

Bu kurs kapsamında çeşitli kütüphanelerle çalıştık ve bunları gerçek senaryolar üzerinde uyguladık. İşte bazı kullanılan kütüphaneler:

- **FluentValidation Kütüphanesi**
  - Giriş verilerinin doğrulamasını kolaylaştıran bir kütüphanedir.
- **AutoMapper Kütüphanesi**
  - Nesneler arasında kolay veri eşleştirmesi sağlayan bir kütüphanedir.
- **AspNetCoreRateLimit Kütüphanesi**
  - API isteklerini sınırlayan ve hız sınırlaması sağlayan bir kütüphanedir.
- **Swagger Kütüphanesi**
  - API'lar için ayrıntılı belgeleme oluşturan bir kütüphanedir.
- **NLog Kütüphanesi**
  - Loglama için kullanılan bir kütüphanedir.
- **Hangfire Kütüphanesi**
  - Arka plan görevleri için kullanılan bir kütüphanedir.
- **Smidge Kütüphanesi**
  - Statik dosya yönetimi için kullanılan bir kütüphanedir.
  
  
## SOLID Prensipleri 

﻿Solid (S.O.L.I.D.) - Bu kurs boyunca SOLID prensiplerini öğrendik ve gerçek senaryolar üzerinde uyguladık:

- **Single Responsibility Principle (Tek Sorumluluk Prensibi)**
  - Bir sınıfın sadece tek bir sorumluluğu olmalıdır. Örnek olarak, bir kullanıcı nesnesi sadece kullanıcı bilgilerini tutmalı ve başka bir işlevi olmamalıdır.Her sınıfın yalnızca tek bir değişiklik nedeni olmalıdır.
- **Open Closed Principle (Açık Kapalı Prensibi)**
  - Bir sınıfın, yeni davranışları eklemek veya mevcut davranışları değiştirmek için genişletilebilir olması gereklidir. Ancak, mevcut kodun değiştirilmemesi önemlidir. Bu sayede, kodun tekrar kullanılabilirliği ve sürdürülebilirliği artırılır. Bir sınıf, yeni davranışlar ekleyebilmelidir ancak mevcut kodu değiştirmemelidir. Örnek olarak, bir ödeme sistemi sınıfı yeni ödeme yöntemleri ekleyebilmeli ancak mevcut ödeme yöntemlerini değiştirmemelidir.
- **Liskov Substitution Principle (Liskov Yerine Geçme Prensibi)**
  - Üst bir sınıfın, türetilmiş sınıflar tarafından her zaman yerine konulabilir olması önemlidir. Yani, bir üst sınıf nesnesinin kullanıldığı herhangi bir yerde, türetilmiş sınıfların da aynı şekilde kullanılması gerekmektedir. Bu prensip, kodun doğruluğunu ve güvenilirliğini sağlayarak polimorfizmi destekler. Üst sınıflar, türeyen sınıflar tarafından yerine geçilebilir olmalıdır. Örnek olarak, bir şekil sınıfının alt sınıfları (kare, daire vb.) şekil sınıfının yerine geçebilmelidir.
- **Interface Segregation Principle (Arayüz Ayırma Prensibi)**
  - Geniş arayüzler yerine, ihtiyaç duyulan özelliklere yönelik daha küçük ve özelleştirilmiş arayüzler kullanılmalıdır. İstemciler, sadece kullandıkları metotlara bağımlı olmalı ve gereksiz metodlar içeren arayüzlerle ilişkili olmamalıdır. Bu prensip, bağımlılıkları azaltır ve sınıflar arasındaki ilişkileri daha esnek hale getirir. İstemciler, ihtiyaç duymadıkları özellikleri içeren büyük arayüzler yerine daha özelleştirilmiş arayüzleri kullanmalıdır. Örnek olarak, bir arayüzün genel özelliklerini içeren bir arayüz ve daha spesifik işlevleri içeren ayrı arayüzler kullanılabilir.
- **Dependency Inversion Principle (Bağımlılıkları Tersine Çevirme Prensibi)**
  - Bağımlılıklar, soyutlamalara ve somut uygulamalara bağımlı olmamalıdır. Bunun yerine, yüksek seviyeli modüller düşük seviyeli modüllere bağımlı olmamalıdır. Soyutlamalar, düşük seviyeli detaylardan izole edilmelidir. Bu prensip, bağımlılıkları azaltır ve yazılımın yeniden kullanılabilirliğini artırır. Yüksek seviyeli modüller, düşük seviyeli modüllere bağımlı olmamalıdır. Soyutlamalar, düşük seviyeli detaylardan izole edilmelidir. Örnek olarak, bir veritabanı bağlantı sınıfı yüksek seviyeli bir servis tarafından çağrılmalı ve doğrudan veritabanıyla ilişkili detaylar içermemelidir.
    
Bu SOLID prensipleri, yazılım geliştirme sürecinde daha temiz, esnek ve sürdürülebilir bir kod tabanı oluşturmayı hedefler. Bu prensiplere uymak, kodun daha kolay anlaşılmasını, değişikliklere daha iyi uyum sağlamasını ve yeniden kullanılabilirliği artırmasını sağlar.
## Kullanılan Kütüphaneler ve Konu Başlıkları

Bu kurs kapsamında çeşitli kütüphanelerle çalıştık ve aşağıdaki konu başlıklarını detaylandırdık:

### Fluent Validation Kütüphanesi

FluentValidation, giriş verilerinin doğrulamasını kolaylaştıran bir kütüphanedir.
- Örnek olarak, bir formun doğru şekilde doldurulup doldurulmadığını kontrol etmek için kullanılabilir.
- Bu kütüphane, projelerde veri aktarımını kolaylaştırarak tekrarlanan kodu azaltabilir ve geliştirme sürecini hızlandırabilir.

### AutoMapper Kütüphanesi

AutoMapper, nesneler arasında kolay veri eşleştirmesi sağlayan bir kütüphanedir. 
- Örnek olarak, veritabanından alınan bir kullanıcı nesnesini, kullanıcı arayüzüne uygun hale getirmek için kullanılabilir.

### RateLimit Kütüphanesi

AspNetCoreRateLimit, API isteklerini sınırlayan ve hız sınırlaması sağlayan bir kütüphanedir.
- Örnek olarak, bir API'nin belli bir süre içinde alabileceği istek sayısını kontrol etmek için kullanılabilir.
-  API tabanlı projelerde, istemcilere yönelik yapılan isteklerin belirli bir oranda sınırlanması ve aşırı kullanımın engellenmesi için kullanılabilir.
-  Uygulamanın güvenliğini artırabilir ve performansını optimize edebilir.

### Smidge Kütüphanesi

Smidge, web uygulamasında statik dosya yönetimi için kullanılan bir kütüphanedir. 
- Örnek olarak, CSS ve JavaScript dosyalarınızı optimize etmek ve etkin bir şekilde yönetmek için kullanılabilir.
- Web sayfalarının yükleme sürelerini azaltarak kullanıcı deneyimini iyileştirebilirsiniz. Bu kütüphane, web uygulamalarının performansını artırmak için ideal bir araçtır.

### Hangfire ile Job Oluşturma ve Hangfire Dashboard

Hangfire, arka planda çalışan işleri yönetmek için kullanılan bir kütüphanedir.
- Kullanıcıya ait belirli işlemleri zamanlayarak veya sürekli çalıştırarak kullanılabilir.
- Hangfire Dashboard aracılığıyla görevlerin durumunu izleyebilir ve yönetebilirsiniz. Bu kütüphane, özellikle arka plan işlemleri gerektiren projelerde kullanışlıdır.

### ErrorHandling ile Hata Tespiti

AspNet Core Web uygulamalarında hata yönetimi ve hata sayfaları, kullanıcı deneyimini iyileştirmek için önemlidir.
- Hata yönetimi için ASP.NET Core Middleware kullanımını öğrenip özelleştirilmiş hata sayfalarının oluşturulması sağlar.
- Kullanıcıya daha anlaşılır hata mesajları sunabilir.
- Uygulamanın hatalarla başa çıkmasını sağlayabilir.

## Hata Yönetimi ve Sayfaları
AspNet Core web uygulamalarında hata yönetimi ve hata sayfaları, kullanıcı deneyimini iyileştirmek için önemlidir. Bu kurs boyunca aşağıdaki konulara değindik:
- Hata yönetimi için ASP.NET Core Middleware kullanımı
- Özelleştirilmiş hata sayfalarının oluşturulması
- Hata loglama ve izleme
- Örnek olarak, doğru şekilde hata mesajlarının gösterilmesi ve hataların izlenmesi için kullanılabilir.
  
## Logging - NLog Loglama Kütüphanesi 
NLog, loglama için kullanılan bir kütüphanedir. Örnek olarak, uygulamanın çalışma durumuyla ilgili bilgilerin kaydedilmesi ve analiz edilmesi için kullanılabilir.
AspNet Core web uygulamalarında loglama işlemi, uygulamanın performansını ve güvenilirliğini sağlar. Loglama çeşitleri arasında dosya tabanlı loglama, veritabanı tabanlı loglama ve üçüncü taraf loglama servislerinin kullanımı gibi konuları öğrenerek uygulamanızın güvenilirliğini artırabilirsiniz. Bu kurs kapsamında aşağıdaki konular ele alındı:
- Loglama temel kavramları ve seviyeleri (Debug, Info, Error, vb.)
- Loglama kütüphanelerinin kullanımı (NLog gibi)
- Loglama çeşitleri: dosya tabanlı loglama, veritabanı tabanlı loglama
- Üçüncü taraf loglama servislerinin kullanımı
NLog, loglama için kullanılan bir kütüphanedir. Örnek olarak, uygulamanın çalışma durumuyla ilgili bilgilerin kaydedilmesi ve analiz edilmesi için kullanılabilir.

## Swagger Kullanımı  ile Ayrıntılı Dökümantasyon
AspNet Core Web API uygulamalarında Swagger, API'larınızı ayrıntılı bir şekilde belgelemek için kullanabilirsiniz.Swagger, API'lar için ayrıntılı belgeleme oluşturan bir kütüphanedir. Örnek olarak, API'ların doğru şekilde belgelendirilmesi ve istemcilere sunulması için kullanılabilir.Swagger UI aracılığıyla API endpoint'lerini görsel olarak inceleyebilir ve API dokümantasyonunu otomatik olarak oluşturabilirsiniz. Bu kütüphane, API tabanlı projelerde belgeleme sürecini kolaylaştırır ve API'larınızın daha anlaşılır olmasını sağlar. Bu kurs kapsamında aşağıdaki konular ele alındı:

- Swagger'ın nasıl entegre edileceği
- Swagger'ın nasıl yapılandırılacağı
- Swagger UI'nin nasıl kullanılacağı
- Ayrıntılı API belgelerinin nasıl oluşturulacağı
- API'lar için parametrelerin, dönüş tiplerinin ve durum kodlarının nasıl belgelendirileceği
Swagger, API'lar için ayrıntılı belgeleme oluşturan bir kütüphanedir.
- Örnek olarak, API'ların doğru şekilde belgelendirilmesi ve istemcilere sunulması için kullanılabilir.

## Environment Ortamlar ile Çalışmak
AspNet Core Web uygulamalarında environment ortamları, farklı ortamlarda (geliştirme, test, canlı vb.) çalışmak için kullanılır.Örnek olarak, geliştirme, test ve canlı ortamlarda uygulamanın nasıl farklı davranacağının belirlenmesi için kullanılabilir. Bu kurs kapsamında aşağıdaki konular ele alındı:

- Hazır environment ortamlarının nasıl kullanılacağı (Development, Staging, Production)
- Özelleştirilmiş environment ortamlarının nasıl oluşturulacağı
- Canlıda environment ortamının nasıl değiştirileceği

AspNet Core Web uygulamalarında environment ortamları, farklı ortamlarda çalışmak için kullanılır. Örnek olarak, geliştirme, test ve canlı ortamlarda uygulamanın nasıl farklı davranacağının belirlenmesi için kullanılabilir.













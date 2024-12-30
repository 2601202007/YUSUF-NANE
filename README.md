# C# Bankacılık Uygulaması Proje Raporu

Bu proje, temel bankacılık işlemlerini gerçekleştirmek için geliştirilen bir konsol uygulamasıdır. Kullanıcıların hesap oluşturma, hesap bilgilerini görüntüleme, para yatırma ve çekme gibi işlemleri gerçekleştirebileceği bir sistem sunmaktadır.

## 1. Projenin Amacı

Bu proje, kullanıcıların hesap oluşturma, hesap bilgilerini görüntüleme, para yatırma ve çekme gibi temel bankacılık işlemlerini gerçekleştirebileceği bir konsol uygulaması geliştirmeyi amaçlamaktadır.

## 2. Nesne Yönelimli Programlama (OOP) Kullanımı

Proje, Nesne Yönelimli Programlama (OOP) prensiplerini etkin bir şekilde uygulamaktadır.

*   **Sınıflar ve Nesneler:** Uygulama, `Account`, `SavingsAccount`, `CheckingAccount` ve `BankSystem` gibi sınıflar kullanılarak modüler bir yapıda tasarlanmıştır. Bu sınıflar, bankacılık işlemlerinin farklı yönlerini ele alır ve işlevselliği bölümlere ayırır.
*   **Kalıtım (Inheritance):** `SavingsAccount` ve `CheckingAccount` sınıfları, `Account` adlı temel sınıftan türetilmiştir. Bu yapı, kodun tekrarını azaltır ve hesap türlerinin ortak özelliklerini merkezi bir yerde toplar.
*   **Soyutlama (Abstraction):** `Account` sınıfı, soyut bir sınıf olarak tanımlanmıştır. Bu sınıf içinde tanımlanan `CalculateInterest` metodu, her hesap türü için özelleştirilmiştir. Bu sayede, farklı hesap türlerine özgü işlemler kolayca tanımlanabilir.
*   **Polimorfizm (Polymorphism):** Farklı hesap türleri, `CalculateInterest` metodunu kendi ihtiyaçlarına göre uyarlamıştır. Örneğin, tasarruf hesaplarında faiz hesaplanırken, vadesiz hesaplarda bu işlev uygulanmaz.
*   **Kapsülleme (Encapsulation):** Sınıfların özellikleri, yalnızca ilgili sınıflar veya türeyen sınıflar tarafından erişilebilir şekilde sınırlandırılmıştır. Bu yaklaşım, verilerin bütünlüğünü korur ve doğrudan müdahaleleri engeller.

## 3. Fonksiyonel Özellikler

*   **Hesap Oluşturma:** Kullanıcı, tasarruf veya vadesiz hesap türünden birini seçerek yeni bir hesap oluşturabilir. Bu işlem sırasında hesap numarası, hesap sahibi adı, açılış tarihi, PIN ve (tasarruf hesapları için) faiz oranı bilgileri girilir.
*   **Hesap Görüntüleme:** Sistemde mevcut olan tüm hesapların bilgileri kullanıcıya sunulur. Her hesap için hesap numarası, hesap sahibi adı, bakiye ve açılış tarihi gibi bilgiler görüntülenir.
*   **Para İşlemleri:** Kullanıcılar, belirli bir hesap üzerinde para yatırma veya çekme işlemleri gerçekleştirebilir. Ayrıca, tasarruf hesapları için faiz hesaplanabilir ve işlem geçmişi incelenebilir.
*   **Hesap Arama:** Kullanıcılar, hesap numarası veya hesap sahibinin adı ile hesap arayabilir. Bu özellik, özellikle çok sayıda hesabın bulunduğu durumlarda kolaylık sağlar.
*   **Hesap Silme:** Kullanıcı, bir hesap numarası ve PIN girerek sistemi güncel tutmak amacıyla hesap silebilir.

## 4. Güçlü Yönler

*   **Modülerlik ve Yeniden Kullanılabilirlik:** Sınıfların ayrıştırılmış olması, yeni özellikler eklenmesini ve mevcut kodun yeniden kullanılmasını kolaylaştırır.
*   **Kullanıcı Dostu Tasarım:** Menü tabanlı bir sistem kullanılarak kullanıcıların işlemleri kolaylıkla gerçekleştirebilmesi sağlanmıştır.
*   **Genişletilebilirlik:** Sistem, yeni hesap türlerinin veya özelliklerin kolayca eklenebilmesine olanak tanır.

## 5. Eksiklikler ve İyileştirme Önerileri

*   **Hata Yönetimi:** Kullanıcıdan alınan girdilere yönelik daha kapsamlı hata kontrolleri eklenmelidir. Örneğin, geçersiz tarih veya negatif miktar girişleri daha kullanıcı dostu bir şekilde ele alınabilir.
*   **Veri Güvenliği:** Hesap PIN’lerinin güvenliği artırılmalı ve şifreleme yöntemleri kullanılmalıdır.
*   **Çoklu Kullanıcı Desteği:** Uygulama, aynı anda birden fazla kullanıcı tarafından kullanılabilir hale getirilebilir.
*   **Görsellik ve Kullanılabilirlik:** Konsol tabanlı menüler, görsel bir arayüz veya web tabanlı bir sistem ile geliştirilebilir.

## 6. Sonuç

Bu proje, OOP prensiplerini etkili bir şekilde kullanarak bir bankacılık sistemi örneği sunmaktadır. Sistem, temel bankacılık işlemlerini yerine getirecek kadar güçlü ve genişletilebilir bir yapıya sahiptir. Kullanıcı deneyimi ve veri güvenliği açısından yapılacak iyileştirmelerle, gerçek dünyada kullanılabilir bir uygulamaya dönüştürülebilir.

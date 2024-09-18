# Rüya Tabirleri Botu

Bu proje, Blazor kullanarak bir kullanıcı arayüzü ve ASP.NET Core kullanarak bir backend yapısı oluşturur. OpenAI'nin Dotnet API'si ile GPT modelini kullanarak RAG (Retrieval-Augmented Generation) yöntemini uygular ve bir JSON dosyasındaki verileri kullanarak rüya tabirleri sağlar.

## Proje Akışı

### 1. Frontend (Blazor)
**Teknoloji:** Blazor WebAssembly veya Blazor Server  
**Amaç:** Kullanıcıların rüyalarını yazabilecekleri bir arayüz ve tabir sonuçlarını görebilecekleri bir ekran oluşturmak.  
**Adımlar:**  
- Rüyanın yazılacağı bir metin kutusu ve "Yorumla" butonu oluştur.
- Yorum sonuçlarını göstermek için bir alan hazırla.

### 2. Backend (ASP.NET Core API)
**Teknoloji:** ASP.NET Core Web API  
**Amaç:** Kullanıcıdan gelen rüya verilerini işlemek ve OpenAI API ile GPT modeline göndererek cevap almak.  
**Adımlar:**  
- API uç noktaları oluştur.
- OpenAI API'yi entegre ederek GPT modeline istek gönder ve sonuçları geri al.

### 3. Veri İşleme (RAG - Retrieval-Augmented Generation)
**Yöntem:** RAG (Retrieval-Augmented Generation)  
**Amaç:** 100 rüya verisinin bulunduğu JSON dosyasını kullanarak, kullanıcıdan gelen rüya verileri ile eşleşmeler yapıp, GPT'ye en uygun soruları yöneltmek.  ( Veri genişletilebilir de.)
**Adımlar:**  
- JSON verilerini okuma ve işleme.
- Kullanıcı rüyası ile JSON'daki verileri eşleştir.
- Elde edilen verilerle GPT'ye gönderilecek prompt oluştur.

### 4. OpenAI API (GPT ile Entegrasyon)
**Teknoloji:** OpenAI API (Dotnet OpenAI API)  
**Amaç:** GPT modeline rüya tabirleri sormak ve sonuçları almak.  
**Adımlar:**  
- Kullanıcının rüyasını ve JSON dosyasından alınan verileri içeren bir prompt oluştur.
- OpenAI API üzerinden bu prompt'u GPT'ye gönder ve cevabı al.

### 5. Veri Yönetimi (JSON)
**Teknoloji:** JSON  
**Amaç:** 100 veriden oluşan rüya tabirleri verilerini RAG yapısında GPT'ye sunmak.  
**Adımlar:**  
- JSON dosyasını backend'de işleyerek RAG sürecinde kullanılacak verileri hazırla.

### 6. Sonuçların Görüntülenmesi
**Teknoloji:** Blazor (Frontend)  
**Amaç:** OpenAI API'den alınan tabir sonuçlarını kullanıcıya göstermek.  
**Adımlar:**  
- Backend'den gelen sonuçları Blazor arayüzünde göster.

### 7. Test ve Optimizasyon
**Yöntem:** Performans ve doğruluk analizleri  
**Amaç:** Hem frontend hem de backend'in düzgün çalıştığını kontrol etmek ve RAG yönteminin doğruluğunu artırmak.  
**Adımlar:**  
- Blazor ve ASP.NET Core'u entegre çalıştırarak tüm süreci test et.
- GPT'ye gönderilen prompt'ları ve JSON verilerini optimize et.

## Gereksinimler
- .NET SDK 6.0 veya üzeri
- Blazor WebAssembly veya Server
- ASP.NET Core Web API
- OpenAI API Anahtarı
- JSON Dosyası (100 veri içeren rüya tabirleri)

## Kullanım

- Kullanıcı, rüya tabirini Blazor arayüzü üzerinden yazar.
- Backend, bu veriyi JSON dosyasındaki rüyalarla eşleştirir.
- OpenAI API üzerinden GPT modeline istek yapılır ve sonuçlar geri döner.
- Sonuçlar Blazor arayüzünde kullanıcıya gösterilir.


![image](https://github.com/user-attachments/assets/c3b8423a-7702-4358-8a14-55281b96778b)

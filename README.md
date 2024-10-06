# Dotnet Mystic 🔮

![ezgif-1-a61c8051cb](https://github.com/user-attachments/assets/392aa3e8-229a-4c2f-8f5d-97b234628ee0)


Bu proje, OpenAI'nin GPT modelini kullanarak rüyalarınızı yorumlayan bir bot oluşturmayı amaçlar. Blazor tabanlı bir ön yüz ve ASP.NET Core Web API tabanlı bir arka yüz içerir. RAG (Retrieval-Augmented Generation) yöntemini kullanarak JSON dosyasındaki rüya verileriyle kullanıcının rüyasını eşleştirir ve sonuçları GPT üzerinden sağlar.

## Proje Akışı

### 1. Ön Yüz (Blazor)
- **Teknoloji:** Blazor WebAssembly veya Blazor Server  
- **Amaç:** Kullanıcıların rüyalarını yazabileceği ve sonuçları görebileceği bir kullanıcı arayüzü.
- **Özellikler:** 
  - Rüya metni girişi için bir metin kutusu
  - Yorum sonuçlarının görüntülenmesi
  - Kullanıcıya, bot tarafından rüyalarıyla ilgili açıklamalar yapabilen bir mesajlaşma arayüzü

### 2. Arka Yüz (ASP.NET Core API)
- **Teknoloji:** ASP.NET Core Web API  
- **Amaç:** Kullanıcıdan alınan rüya verisini GPT modeline göndermek ve sonuçları döndürmek.
- **Özellikler:** 
  - OpenAI API ile entegrasyon
  - Kullanıcı rüya verisinin işlenmesi ve API üzerinden yorumlanması

### 3. RAG Yöntemi (Veri İşleme)
- **Yöntem:** Retrieval-Augmented Generation (RAG)  
- **Amaç:** JSON dosyasında bulunan rüya verilerini kullanarak, kullanıcının girdiği rüya ile en uygun veriyi eşleştirip GPT'ye göndermek.
- **Veri Yönetimi:** 100 rüya yorumu içeren bir JSON dosyası işlenir ve GPT'ye en uygun istemler gönderilir.

### 4. OpenAI GPT Entegrasyonu
- **Teknoloji:** OpenAI API (Dotnet)  
- **Amaç:** GPT modelinden rüya yorumlarını almak ve kullanıcıya sunmak.
- **Özellikler:** 
  - Kullanıcı tarafından yazılan rüya ve JSON verilerinin birleştirilmesi
  - OpenAI API'ye isteğin gönderilmesi ve yanıtın alınması

### 5. JSON Verileri
- **Teknoloji:** JSON  
- **Amaç:** Rüya yorum verilerini tutmak ve kullanıcının rüyasıyla eşleşen verileri kullanarak yorum yapmak.
- **Veri Yapısı:** 100 farklı rüya yorumu içeren bir JSON dosyası kullanılır.

### 6. Sonuçların Gösterimi
- **Teknoloji:** Blazor  
- **Amaç:** OpenAI API'den dönen rüya yorumlarını kullanıcıya göstermek.
- **Özellikler:** Yorum sonuçlarının mesajlaşma arayüzü üzerinde gösterimi.

## Kurulum

1. **Gereksinimler:**
   - .NET SDK 6.0 veya üstü
   - OpenAI API Anahtarı
   - 100 rüya yorumu içeren JSON dosyası

2. **Adımlar:**
   - Proje dosyalarını yerel bilgisayarınıza klonlayın.
   - `appsettings.json` dosyasına OpenAI API anahtarınızı ekleyin.
   - Backend ve frontend projelerini çalıştırmak için .NET komutlarını kullanın:
     ```bash
     dotnet build
     dotnet run
     ```

## Kullanım

1. **Rüya Yazma:**
   - Blazor arayüzünde rüyanızı metin kutusuna yazın.
   - "Yorumla" butonuna tıklayarak rüyanızın GPT modeli tarafından yorumlanmasını bekleyin.

2. **RAG Yöntemi ile Eşleşme:**
   - Backend, yazdığınız rüyayı JSON dosyasındaki 100 rüya verisi ile eşleştirir ve en uygun istemi GPT'ye gönderir.

3. **Sonuçlar:**
   - GPT modelinden gelen rüya yorumu ekranda gösterilir.
   - Rüyanızla ilgili anlamlı ve detaylı bir yorum görürsünüz.

## Geliştirme ve Katkı

Proje ile ilgili geri bildirim ve katkılarınızı bekleriz. Aşağıdaki adımları izleyerek projeye katkıda bulunabilirsiniz:

1. Projeyi forklayın
2. Yeni bir dal oluşturun: `git checkout -b yeni-ozellik`
3. Yaptığınız değişiklikleri commit'leyin: `git commit -m 'Yeni özellik eklendi'`
4. Dalları birleştirin: `git push origin yeni-ozellik`
5. Bir pull request oluşturun

## Lisans
Bu proje MIT lisansı altında lisanslanmıştır.

---

**Hayırlara vesile olur inşallah!** 🤗

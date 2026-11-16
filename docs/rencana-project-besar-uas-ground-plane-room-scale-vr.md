# Rencana Pengerjaan Project Besar UAS — Ground Plane (AR) + Room-Scale (VR)

Kelompok: Kelompok 4 (DESAIN AR VR) · Metode tugas: **Kelompok 2 — Ground Plane (AR) + Room-Scale (VR)**
Dosen: Fizar Syafa'at · Engine: Unity (disarankan) · File brief: `VR.pptx` (27 slide)

---

## 1. Ringkasan aturan dari PPTX (wajib dipenuhi — jangan dilanggar)

**Anggota & peran (slide 21):** 10 peran wajib ada dan dicantumkan di laporan — Project Leader, Lead Developer, AR Specialist, VR Specialist, UI/UX Designer, 3D Artist, QA/Tester, DevOps/Cloud, Documentation, Presenter/Demo. Kalau anggota kelompok kurang dari 10, satu orang merangkap beberapa peran (lihat pembagian di bawah).

**Deliverables (slide 21–22) — semua wajib, dalam satu paket zip/repo:**
1. Kode sumber lengkap di GitHub/GitLab + link repo.
2. Struktur repo jelas: `/src`, `/assets`, `/build`, `/docs`, `/demo` + file README (cara build/run).
3. Video demo **maks 7 menit**, min 720p, upload ke Drive: isi = setup perangkat, demo AR → transisi ke VR, highlight fitur utama, error handling.
4. Laporan proyek PDF **6–12 halaman**: Tujuan, metode (teknis), arsitektur sistem, alat & versi, flow AR→VR, masalah & solusi, pengujian (usability + performance), pembagian kerja, refleksi.
5. Slide presentasi **maks 10 menit** (PPTX/PDF).
6. File assets (model 3D, tekstur) + lisensi aset (kalau pakai aset luar).

**Teknologi (slide 22):** Unity (disarankan) atau Unreal. AR SDK: Vuforia / ARCore / ARKit / OpenCV. VR SDK: OpenXR / Oculus SDK / SteamVR. Perangkat: headset Quest/Quest 2/Pro, PC+HMD, atau smartphone AR. Version control: **Git (wajib)**.

**Keamanan & etika (slide 23):** Jangan pakai aset berlisensi komersial tanpa izin; cantumkan sumber aset. Kalau pakai data wajah orang, harus ada izin tertulis.

**Originalitas (slide 23):** Library umum boleh dipakai, tapi **fungsi inti & skenario harus original**. Plagiarisme / copy-paste proyek orang lain tanpa atribusi = **nilai 0**.

**Struktur laporan (slide 23):** Halaman Judul (nama kelompok, anggota, peran) → Abstrak (≤200 kata) → Tujuan & Scope → Metode & Tools (teknis) → Arsitektur Sistem & Flow AR→VR (diagram) → Implementasi (highlight kode, algoritme) → Pengujian & Hasil (SSQ, perf) → Masalah & Solusi → Kesimpulan & Pengembangan Lanjutan → Referensi & Lisensi Aset → Lampiran (link repo, build, video).

**Tugas Kelompok 2 (slide 25):** AR — letakkan model interaktif di permukaan nyata (meja/lantai) dan gunakan dataset objek itu sebagai titik awal untuk membuat pengalaman Room-Scale VR di mana pengguna bisa berjalan mengelilingi replika lingkungan.

---

## 2. Keputusan awal (buat SEBELUM coding — ini yang paling menentukan)

| # | Keputusan | Rekomendasi | Catatan |
|---|-----------|-------------|---------|
| 1 | **Tema & konsep** | **DIPUTUSKAN 2026-11-16: Coffee Shop (kafe).** Miniatur kafe → VR: masuk ke dalam kafe skala penuh, jalan keliling ruangan. **Konsepnya bukan sekadar pajangan — tapi alat perancang interior kafe:** pemilik kafe bisa mencoba susunan meja, warna dinding, dan warna counter di VR, untuk melihat hasilnya SEBELUM renovasi beneran (pola yang sama dengan ide dosen di project kaleng: ubah label & warna sebelum rebranding). **Model 3D di-download** dari Sketchfab (kata kunci "Low Poly Coffee Shop", lisensi CC0/CC BY, format .fbx — lihat tutorial download). Yang dibangun sendiri: penempatan AR, transisi, interaksi VR, UI, video, laporan | Alternatif yang sempat dipertimbangkan: Rumah Adat (terlalu kompleks), Kamar/Ruang Tamu, Rumah modern. Tema sudah diputuskan: Coffee Shop — jangan ganti di tengah jalan. |
| 2 | **Perangkat VR** | **DIPUTUSKAN 2026-11-13: HP Android saja, tanpa Cardboard.** Tidak ada headset Quest yang bisa dipinjam. VR dibangun dengan **OpenXR + XR Interaction Toolkit** supaya siap jalan di Quest kapan pun tanpa ubah kode. Mode VR di HP: "jendela ajaib" (gerakkan HP untuk melihat, tombol di layar untuk teleport) + mode walkthrough di PC (WASD + mouse) sebagai cadangan demo | Room-Scale sejati butuh headset 6DoF (Quest). Di HP, gerak fisik tidak terbaca — diganti teleportasi. Jangan klaim mode HP sebagai room-scale penuh; tulis jujur di laporan. HP uji wajib punya giroskop: Galaxy A23 bisa; Galaxy A15 TIDAK punya giroskop — jangan dipakai untuk VR. |
| 3 | **SDK AR** | **AR Foundation + ARCore XR Plugin** (gratis, plane detection bawaan, standar industri) | Vuforia juga diizinkan PPTX, tapi ARCore lebih pas untuk ground plane dan gratis. |
| 4 | **SDK VR** | **OpenXR Plugin + XR Interaction Toolkit** (gratis, standar Unity) | Sama-sama gratis, dokumentasi lengkap. |
| 5 | **Unity** | **Unity 2022.3 LTS** (versi yang sudah dipakai di project AR kemarin — 2022.3.62f3) | Jangan pindah ke Unity 6: pengalaman kemarin membuktikan SDK AR bisa crash di Unity 6. |
| 6 | **Repo** | GitHub, private/public sesuai aturan dosen, struktur `/src`, `/assets`, `/build`, `/docs`, `/demo` | Buat repo di hari pertama, jangan di akhir. |

---

## 3. Arsitektur sistem (konsep inti — pahami dulu, baru bangun)

- **Satu project Unity, dua scene:**
  - `ARScene` — mode AR: kamera HP mendeteksi permukaan (meja/lantai), pengguna tap untuk meletakkan **miniatur** kafe (skala kecil, sekitar 36 cm — rumus 0,4 ÷ lebar kafe).
  - `VRScene` — mode VR: **replika kafe skala 1:1** — pengguna berjalan mengelilingi / masuk ke dalamnya.
- **Kunci integrasi (ini yang dinilai dosen):** model 3D yang SAMA dipakai di dua scene dengan dua skala — inilah "dataset objek" yang dimaksud slide 25. AR = miniatur di meja, VR = replika yang bisa dimasuki.
- **Transisi AR → VR:** tombol "Masuk VR" di ARScene → `SceneManager.LoadScene("VRScene")`. Tombol "Kembali ke AR" di VRScene → kembali ke ARScene.
- **Fitur inti (yang membedakan dari sekadar demo): kustomisasi.** Di VR, pengguna bisa mengubah warna dinding, mengganti warna counter, dan memindah meja & kursi (termasuk pilihan susunan meja) — untuk melihat hasilnya sebelum renovasi beneran. Inilah "alat perancang" yang dosen harapkan (sama polanya dengan ide rebranding kaleng: ubah label & warna sebelum produksi).
- **Mode VR di HP (tanpa headset):** "jendela ajaib" — gerakkan HP untuk melihat sekeliling (pakai sensor giroskop), teleport & interaksi lewat tombol di layar. Dibangun dengan OpenXR + XR Interaction Toolkit, jadi kalau suatu saat dicoba di Quest, langsung jalan tanpa ubah kode.
- **Manager:** `GameManager` (menyimpan model & info yang dipilih, `DontDestroyOnLoad`), `ARPlaceManager` (placement + interaksi AR), `VRInteractionManager` (interaksi VR).

---

## 4. Langkah pengerjaan (step by step)

### FASE 0 — Persiapan (Minggu 1)
1. Rapat kelompok: tema SUDAH diputuskan 2026-11-16 — **Coffee Shop** + konsep alat perancang interior kafe (coba susunan meja, warna dinding, warna counter sebelum renovasi). Tetapkan pembagian peran (lihat §6).
2. Buat repo GitHub dengan struktur `/src`, `/assets`, `/build`, `/docs`, `/demo` + README awal.
3. ~~Tanya Quest~~ — SUDAH DIJAWAB 2026-11-13: tidak ada headset Quest yang bisa dipinjam. Keputusan: HP saja tanpa Cardboard (lihat §2 baris 2).
4. Cari & pilih model kafe di Sketchfab ("Low Poly Coffee Shop", lisensi CC0/CC BY — ikuti tutorial download), dan catat nama model + pembuat + lisensi + link untuk laporan. Denah patokan kafe ada di `Denah_Coffee_Shop_UAS.md`.
5. Bagi tugas per orang (lihat §6) dan buat jadwal mingguan.

### FASE 1 — Setup project Unity (Minggu 1)
6. Unity Hub → New Project → template **3D (URP)** → nama mis. `VRGroundPlaneRoomScale`.
7. File → Build Settings → Android → Switch Platform.
8. Package Manager → install: **AR Foundation**, **ARCore XR Plugin**, **XR Plugin Management**, **OpenXR Plugin**, **XR Interaction Toolkit** (pilih versi yang kompatibel dengan Unity 2022.3 LTS).
9. Edit → Project Settings → XR Plug-in Management → centang **ARCore** (tab Android) dan **OpenXR** (tab Android / Standalone).
10. Player Settings: Package Name `com.kelompok4.vrgroundplane` (sesuaikan), Minimum API Level 26, Scripting Backend **IL2CPP**, Target Architectures **ARM64** (pelajaran dari project kemarin: Mono = ARM64 tidak bisa dicentang), Graphics API **OpenGLES3** saja.
11. Commit pertama ke GitHub: project kosong + README cara build/run.

### FASE 2 — Aset 3D (Minggu 1–2)
12. Download model 3D kafe dari Sketchfab (ikuti tutorial `tutorial-download-model-coffee-shop-uas.md` — kata kunci "Low Poly Coffee Shop", format .fbx, lisensi CC0/CC BY). Import ke `Assets/Models/Kafe`, perbaiki Scale Factor & material (URP Lit kalau pink), lalu **cek bagian-bagiannya terpisah** (dinding, counter, meja, kursi) supaya fitur kustomisasi bisa jalan. **Catat nama model + pembuat + lisensi + link** (wajib untuk laporan).
13. Buat prefab `Kafe_Mini` (skala kecil — miniatur sekitar 36 cm: Scale 0,06 untuk kafe 6 m) dan `Kafe_Full` (skala 1:1) dari model yang sama.
14. Buat objek interaktif di dalam kafe: pintu (bisa dibuka), counter, meja & kursi (bisa dipindah), papan menu, beberapa titik info (mis. counter, mesin kopi, area duduk). Kalau ada bagian yang tidak ada di model download (mis. tanaman, papan menu), buat sendiri dari kotak (Cube) di Unity.
15. Buat/atur material & tekstur: kayu (counter & meja), dinding, lantai — warna dan tekstur sederhana tapi rapi (URP Lit).
16. Optimasi: gabungkan mesh bila perlu, jaga jumlah polygon wajar (target HP: total < 100k triangles untuk scene AR, < 300k untuk VR Quest).

### FASE 3 — AR: Ground Plane (Minggu 2–3)
17. Buat scene `ARScene`: tambahkan **AR Session** + **AR Session Origin** (dengan AR Camera) + **AR Plane Manager** + **AR Raycast Manager**.
18. Buat script `ARPlaceManager.cs`: raycast dari sentuhan layar ke plane yang terdeteksi → letakkan prefab miniatur di titik itu.
19. Tambahkan **reticle/indikator** (lingkaran kecil) yang mengikuti plane sebelum model diletakkan — supaya pengguna tahu di mana model akan muncul.
20. Tambahkan interaksi sentuh: tap bagian model → panel info muncul (nama bagian + penjelasan singkat); pinch untuk ubah skala miniatur; drag dua jari untuk putar.
21. Tambahkan UI AR: tombol **Putar**, **Perbesar/Perkecil**, **Reset**, dan tombol utama **"Masuk VR"**.
22. Uji di HP (Galaxy A23 — support ARCore): plane terdeteksi di meja & lantai, model menempel stabil, tidak goyang/geser saat HP digerakkan.
23. Catat hasil uji AR: kecepatan deteksi plane, kestabilan tracking, FPS (target ≥ 30 FPS di HP).

### FASE 4 — VR: Room-Scale (Minggu 3–4)
24. Buat scene `VRScene`: tambahkan **XR Origin** (Room-Scale) + **XR Interaction Manager** + **Locomotion System**.
25. Susun lingkungan replika: prefab `Kafe_Full` skala 1:1, lantai, pencahayaan, langit (skybox sederhana), dan batas area (guardian/boundary visual).
26. Locomotion — **Teleportation** (utama, paling nyaman, mengurangi motion sickness): tambahkan Teleportation Provider + Teleportation Area di lantai + Teleportation Anchor di titik-titik penting (depan pintu, tengah ruangan). Di HP tanpa headset, teleport dipicu tombol di layar.
27. **Mode HP ("jendela ajaib"):** kamera VR mengikuti sensor giroskop HP — gerakkan HP untuk melihat sekeliling. Tambahkan tombol di layar untuk teleport & interaksi. Ini mode utama demo & pengujian (tanpa Cardboard, tanpa headset).
28. Interaksi VR: **XR Ray Interactor** (menunjuk dari jauh) + **XR Direct Interactor** (tangan virtual untuk memegang) pada objek: pintu bisa dibuka, titik info bisa ditekan → panel info muncul. Di HP, interaksi lewat tap tombol / tatapan + tombol.
29. **Fitur kustomisasi (inti konsep alat perancang):** script `GantiWarna.cs` — tap dinding/counter lalu pilih warna dari panel → material berubah langsung. Script `PindahPerabot.cs` — pilih meja/kursi lalu tap titik baru di lantai untuk memindahkannya; sediakan juga pilihan susunan meja (mis. 3 meja pisah / 1 meja besar). Sediakan tombol **Reset** untuk kembali ke desain awal.
30. Kenyamanan (comfort) + pengujian di editor: tambahkan vignette saat bergerak (tunneling), batasi kecepatan gerak, hindari akselerasi mendadak. Aktifkan **XR Device Simulator** (bawaan XR Interaction Toolkit) untuk menguji interaksi VR tanpa perangkat; dan buat **mode walkthrough PC** (WASD + mouse) supaya lingkungan tetap bisa didemokan di laptop saat presentasi.
31. Uji di HP (Galaxy A23 — punya giroskop): gerakkan HP untuk melihat, teleport lewat tombol, buka pintu, tekan titik info, ganti warna dinding — pastikan tidak ada objek yang tembus/clipping dan tidak ada lag.

### FASE 5 — Transisi AR → VR (Minggu 4)
32. Buat `GameManager.cs` (`DontDestroyOnLoad`): menyimpan model & data yang dipilih di AR supaya VR tahu replika apa yang harus ditampilkan.
33. Tombol "Masuk VR" di ARScene → `SceneManager.LoadScene("VRScene")` + tampilkan instruksi singkat ("Gerakkan HP untuk melihat sekeliling, pakai tombol di layar untuk berpindah").
34. Tombol "Kembali ke AR" di VRScene → kembali ke ARScene.
35. Uji alur penuh: buka aplikasi → AR (letakkan miniatur) → tap "Masuk VR" → VR (jalan keliling replika) → kembali ke AR. Rekam masalah apa pun yang muncul.

### FASE 6 — UI/UX & audio (Minggu 4)
36. Buat menu awal: judul, tombol "Mulai AR", tombol "Langsung ke VR", tombol "Cara Pakai", tombol "Tentang".
37. Buat panel info yang konsisten di AR dan VR (nama objek, deskripsi singkat, tombol tutup). Buat juga panel kustomisasi di VR: pilihan warna dinding (4–6 warna), pilihan warna perabot, dan tombol Reset Desain — tombol cukup besar untuk ditekan lewat layar HP.
38. Tambahkan audio sederhana: suara klik tombol, dan musik latar lembut (opsional, bebas lisensi — catat sumbernya).
39. Pastikan teks UI terbaca di HP dan di dalam headset (ukuran cukup besar, kontras jelas).

### FASE 7 — Build & pengujian perangkat (Minggu 5)
40. Build APK Android → instal di HP → uji AR lengkap (meja, lantai, cahaya terang & redup).
41. Uji VR lengkap di HP (A23): teleport, interaksi, kustomisasi warna/perabot, kenyamanan — catat FPS & rasa pusing (untuk SSQ).
42. Uji mode walkthrough PC di laptop (WASD + mouse) sebagai cadangan demo presentasi.
43. Perbaiki bug yang ditemukan; catat semua bug + solusinya (masuk ke laporan bagian Masalah & Solusi).
44. Ukur performa: FPS AR di HP, FPS VR di Quest/HP, waktu loading scene, penggunaan memori — catat angkanya untuk laporan.

### FASE 8 — QA: usability + SSQ (Minggu 5)
45. Uji usability: 5–10 orang coba aplikasi (di luar anggota kelompok) — beri tugas: letakkan model di meja → buka info → masuk VR → teleport ke 2 titik → kembali. Catat: apakah mereka berhasil tanpa bantuan, di mana mereka bingung.
46. **SSQ (Simulator Sickness Questionnaire):** kuesioner standar 16 item (mual, pusing, mata lelah, dll.) — isi SEBELUM dan SESUDAH sesi VR, hitung skornya. Ini wajib ada di laporan (slide 23 menyebut "SSQ, perf").
47. Perbaiki hal yang membingungkan dari hasil uji (UI, instruksi, posisi tombol).
48. Uji ulang setelah perbaikan (minimal 3 orang) — pastikan masalah utama hilang.

### FASE 9 — Deliverables (Minggu 5–6)
49. Rapikan repo: pastikan `/src` (project Unity), `/assets` (model & tekstur + lisensi), `/build` (APK), `/docs` (laporan & slide), `/demo` (video) terisi dan README menjelaskan cara build/run langkah demi langkah.
50. **Video demo (maks 7 menit, min 720p):** rekam layar HP + kamera: (a) setup perangkat, (b) demo AR — letakkan miniatur di meja, (c) transisi ke VR, (d) demo VR — jalan keliling replika, teleport, interaksi, (e) error handling (mis. plane tidak terdeteksi → apa yang dilakukan). Upload ke Drive, salin linknya.
51. **Laporan PDF (6–12 halaman)** mengikuti struktur slide 23 (Judul → Abstrak ≤200 kata → Tujuan & Scope → Metode & Tools → Arsitektur & Flow AR→VR (diagram) → Implementasi (kode) → Pengujian & Hasil (SSQ, perf) → Masalah & Solusi → Kesimpulan → Referensi & Lisensi → Lampiran link repo/build/video).
52. **Slide presentasi (maks 10 menit):** ringkas — masalah, metode, arsitektur, demo (video/screenshot), hasil uji, kesimpulan. Latihan presentasi dengan timer.
53. Cek kelengkapan: semua file deliverables ada, link repo & video bisa dibuka, APK bisa diinstal di HP bersih (bukan HP developer).

### FASE 10 — Gladi demo & presentasi (Minggu 6)
54. Gladi bersih: jalankan demo lengkap dari awal sampai akhir di HP yang sama dengan yang dipakai saat presentasi (Galaxy A23).
55. Siapkan rencana cadangan: kalau plane tidak terdeteksi saat demo → sudah ada video demo sebagai backup; kalau HP bermasalah → mode walkthrough PC di laptop.
56. Bagi peran presentasi (siapa menjelaskan AR, siapa VR, siapa demo) dan siapkan jawaban untuk pertanyaan dosen (script, settings, alasan pilih SDK — seperti bank soal project kemarin).
57. Presentasi. ✅

---

## 5. Checklist akhir (sebelum dikumpulkan)

- [ ] APK terinstal & berjalan di HP (AR) dan di headset/PC (VR)
- [ ] Transisi AR → VR dan VR → AR berfungsi
- [ ] Repo GitHub lengkap (`/src`, `/assets`, `/build`, `/docs`, `/demo` + README)
- [ ] Video demo ≤ 7 menit, ≥ 720p, link Drive aktif
- [ ] Laporan PDF 6–12 halaman sesuai struktur slide 23
- [ ] Slide presentasi ≤ 10 menit
- [ ] Lisensi semua aset luar dicantumkan
- [ ] Hasil uji usability + SSQ + performa ada di laporan
- [ ] Tidak ada kode/hasil copy-paste tanpa atribusi

---

## 6. Pembagian peran (10 peran PPTX → anggota kelompok)

PPTX mewajibkan 10 peran dicantumkan di laporan. Jika kelompok berisi 3 orang (Alifa, Fauzhira, Fadhilah), pembagian yang masuk akal:

| Peran (PPTX) | Penanggung jawab | Alasan |
|---|---|---|
| Project Leader + Lead Developer | **Alifa** | Pengalaman Unity + integrasi paling banyak (project AR kemarin) |
| AR Specialist | **Fauzhira** | Ground plane, placement, interaksi AR |
| VR Specialist | **Alifa** | XR Origin, locomotion, interaksi VR |
| UI/UX Designer | **Fadhilah** | Menu, panel info, alur pengguna |
| 3D Artist | **Fauzhira** | Model kafe (download Sketchfab + penyesuaian) + material + optimasi |
| QA/Tester | **Fadhilah** | Uji usability, SSQ, catat bug |
| DevOps/Cloud | **Alifa** | Repo GitHub, build, upload video Drive |
| Documentation | **Fadhilah** | Laporan PDF + README |
| Presenter/Demo | **Bergiliran** | Alifa (arsitektur), Fauzhira (AR), Fadhilah (VR + demo) |

*Catatan: sesuaikan dengan jumlah anggota sebenarnya — kalau kelompok UAS ini ternyata 10 orang, bagi 1 peran per orang. Yang penting: setiap peran ada namanya di laporan.*

---

## 7. Risiko & mitigasi (jujur, supaya tidak kaget di tengah jalan)

| Risiko | Dampak | Mitigasi |
|---|---|---|
| Tidak ada headset Quest (dikonfirmasi 2026-11-13) | Room-Scale penuh (6DoF) tidak bisa diuji/didemo | Diputuskan: HP saja tanpa Cardboard + walkthrough PC. VR tetap dibangun OpenXR + XR Interaction Toolkit (siap Quest tanpa ubah kode). Tulis jujur di laporan: pengujian 3DoF di HP, room-scale penuh butuh Quest. |
| ARCore tidak support di HP tester | Plane tidak terdeteksi | Uji di HP yang support ARCore (Galaxy A23 support; cek di daftar perangkat ARCore). Siapkan video demo sebagai backup. |
| Model download bagiannya menyatu (satu mesh) | Fitur ganti warna/pindah perabot tidak bisa jalan per bagian | Cek Hierarchy sebelum dipakai (tutorial download langkah 17) — pilih model yang bagiannya terpisah; kalau terpaksa, kustomisasi dibatasi ke bagian yang terpisah saja |
| Model 3D terlalu berat → lag | FPS jatuh, VR bikin pusing | Jaga polygon, pakai tekstur sederhana, ukur FPS sejak awal, bukan di akhir. |
| Scope membesar (tambah fitur terus) | Tidak selesai | Bekukan fitur di akhir Minggu 4. Setelah itu hanya perbaikan bug. |
| Anggota tidak paham bagiannya | Tidak bisa jawab saat ditanya dosen | Tiap orang menulis penjelasan bagiannya sendiri (seperti kemarin) + bank soal per bidang. |

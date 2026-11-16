# Project Besar UAS — Ground Plane (AR) + Room-Scale (VR)

Kelompok: Kelompok 4 (DESAIN AR VR) · Dosen: Fizar Syafa'at
Metode: **Kelompok 2 — Ground Plane (AR) + Room-Scale (VR)**
Tema: Miniatur Coffee Shop / Kafe (AR) → replika skala penuh yang bisa dimasuki (VR)
Konsep: **alat perancang interior kafe** — pemilik kafe bisa mencoba susunan meja, warna dinding, dan warna counter di VR sebelum renovasi beneran (bukan sekadar pajangan). Pola yang sama dengan ide dosen di project kaleng: ubah label & warna sebelum rebranding. Model 3D kafe di-download dari Sketchfab (lisensi CC0/CC BY) — yang dibangun sendiri: penempatan AR, transisi, interaksi VR, UI, video, laporan.

## Cara kerja singkatnya

Satu project Unity, dua scene, satu model 3D yang sama:

- `ARScene` — kamera HP mendeteksi meja/lantai, tap untuk meletakkan miniatur kafe.
- `VRScene` — replika kafe skala 1:1, pengguna jalan keliling di dalamnya.
- Tombol **"Masuk VR"** di ARScene pindah ke `VRScene`; tombol **"Kembali ke AR"** untuk kembali.
- Di VR: tap dinding/counter/meja → pilih warna baru, pindah meja & kursi, lalu **Reset** untuk kembali ke desain awal.

## Alat & versi

| Alat | Versi / catatan |
|---|---|
| Unity | **2022.3 LTS** (2022.3.62f3) — jangan pindah ke Unity 6 |
| AR | AR Foundation + ARCore XR Plugin (ground plane, gratis) |
| VR | OpenXR Plugin + XR Interaction Toolkit (gratis) |
| Build Android | Template 3D (URP), Minimum API 26, IL2CPP, ARM64, OpenGLES3 |
| HP uji | Galaxy A23 (support ARCore + punya giroskop — wajib untuk VR; Galaxy A15 TIDAK punya giroskop, jangan dipakai untuk VR) |
| Headset VR | Meta Quest 2/3 — **tidak ada yang bisa dipinjam (dikonfirmasi 2026-11-13)**. Demo & uji di HP saja, tanpa Cardboard |

## Struktur repo

```
/src        project Unity (ARScene, VRScene, script, prefab)
/assets     model 3D, tekstur, audio + file LISENSI tiap aset luar
/build      APK hasil build
/docs       laporan PDF + slide presentasi
/demo       video demo (maks 7 menit, min 720p)
README.md   file ini
```

## Cara build & jalan (langkah demi langkah)

1. Buka project di Unity Hub (Unity 2022.3 LTS).
2. File → Build Settings → Android → Switch Platform.
3. Package Manager: pastikan AR Foundation, ARCore XR Plugin, XR Plugin Management, OpenXR Plugin, dan XR Interaction Toolkit sudah terpasang.
4. Edit → Project Settings → XR Plug-in Management: centang ARCore (tab Android) dan OpenXR (tab Android / Standalone).
5. Player Settings: Package Name `com.kelompok4.vrgroundplane`, Minimum API Level 26, Scripting Backend IL2CPP, Target Architectures ARM64, Graphics API OpenGLES3 saja.
6. Build APK → instal di HP → buka aplikasi → tap meja/lantai untuk meletakkan miniatur.
7. Tap **"Masuk VR"** untuk pindah ke replika skala penuh.

## Perangkat VR — status (diputuskan 2026-11-13)

- Tidak ada headset Quest yang bisa dipinjam. **Demo & pengujian di HP saja, tanpa Cardboard.**
- Mode VR di HP ("jendela ajaib"): gerakkan HP untuk melihat sekeliling (pakai giroskop), teleport & interaksi lewat tombol di layar. Cadangan demo: mode walkthrough di PC (WASD + mouse).
- VR tetap dibangun dengan **OpenXR + XR Interaction Toolkit**, supaya kalau suatu saat dicoba di Quest, aplikasinya langsung jalan tanpa ubah kode.
- **Jujur di laporan:** mode HP hanya 3DoF (putar kepala saja, jalan fisik tidak terbaca) — jangan diklaim sebagai room-scale penuh (6DoF).

## Pembagian peran (10 peran wajib di laporan)

| Peran | Nama |
|---|---|
| Project Leader | Alifa |
| Lead Developer | Alifa |
| AR Specialist | Fauzhira |
| VR Specialist | Alifa |
| UI/UX Designer | Fadhilah |
| 3D Artist | Fauzhira |
| QA/Tester | Fadhilah |
| DevOps/Cloud | Alifa |
| Documentation | Fadhilah |
| Presenter/Demo | Bergiliran (Alifa: arsitektur, Fauzhira: AR, Fadhilah: VR + demo) |

## Deliverables (cek sebelum dikumpulkan)

- [ ] APK jalan di HP (AR) dan di headset/PC (VR)
- [ ] Transisi AR → VR dan VR → AR berfungsi
- [ ] Video demo ≤ 7 menit, ≥ 720p, link Drive aktif
- [ ] Laporan PDF 6–12 halaman (termasuk SSQ + performa)
- [ ] Slide presentasi ≤ 10 menit
- [ ] Lisensi semua aset luar dicantumkan
- [ ] Hasil uji usability + SSQ + performa ada di laporan
- [ ] Tidak ada kode/hasil copy-paste tanpa atribusi

## Lisensi aset luar

Catat di sini tiap aset yang bukan buatan sendiri: nama aset, sumber, lisensi.

| Aset | Sumber | Lisensi |
|---|---|---|
| (contoh) Model coffee shop | Sketchfab | CC BY |

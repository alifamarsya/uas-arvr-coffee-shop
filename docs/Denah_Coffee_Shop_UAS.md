# Denah Coffee Shop — Tema UAS DESAIN AR VR (DIPUTUSKAN)

**Status: TEMA DIPUTUSKAN 2026-11-16 — Coffee Shop.**
Menggantikan denah Kamar/Ruang Tamu (`Denah_Kamar_Ruang_Tamu_UAS.md` — sudah ditandai digantikan).
File rencana dan README sudah diubah mengikuti tema ini.
Keputusan dibuat Alifa bersama kelompok.

**Denah ini patokan untuk memilih model download.** Model 3D kafe di-download
dari Sketchfab (kata kunci "Low Poly Coffee Shop", lisensi CC0/CC BY — lihat
tutorial download). Cari model yang mirip denah ini: satu ruangan, counter di
dinding belakang, 3 meja di tengah, pintu di depan. Kalau model yang ketemu
ukurannya beda, tidak apa-apa — pakai rumus di bawah untuk miniatur AR-nya.
Bagian yang tidak ada di model download (mis. tanaman, papan menu) bisa dibuat
sendiri dari kotak (Cube) di Unity.

## 1. Bayangannya seperti apa?

Satu ruangan saja, ukuran **6 meter × 4 meter, tinggi 3 meter**.
Di Unity, 1 unit = 1 meter, jadi ruangannya 6 × 4 × 3 unit.

- **Di AR:** ruangan ini dikecilkan jadi miniatur **36 cm × 24 cm** di atas meja.
  Skalanya 0,06 — tinggal tap meja, miniatur muncul. Rumusnya: 0,4 ÷ lebar kafe
  (6 meter) = 0,06. Kalau model download lebarnya beda, hitung ulang dengan rumus
  yang sama supaya miniatur tetap sekitar 40 cm.
- **Di VR:** kafe yang sama dibuka ukuran asli. Alifa masuk lewat pintu, jalan
  keliling di dalam, lalu ganti warna dinding, pindah meja, dan coba susunan meja
  yang lain — persis seperti pemilik kafe mencoba desain sebelum renovasi beneran.

## 2. Denah dari atas (dilihat dari atas, pintu di bawah)

```
          6 meter
  ┌──────────────────────────────────┐
  │  COUNTER       PAPAN MENU        │  ← dinding belakang
  │  (2,5 m)       (1,5 × 0,8 m)     │
  │                                  │
  │    MEJA 1        MEJA 2          │
  │   (0,8 m)        (0,8 m)         │
  │         MEJA 3                   │
  │        (0,8 m)                   │
  │                                  │
  │  TANAMAN             ┌───┐       │
  └──────────────────────┤   ├───────┘
                         PINTU (0,9 m)
          4 meter
```

Keterangan gambar:
- Counter menempel di dinding belakang sebelah kiri, panjang 2,5 meter. Papan menu di dinding belakang di atas counter.
- 3 meja di tengah ruangan, masing-masing 0,8 meter dengan 2 kursi (total 6 kursi).
- Pintu di dinding bawah sebelah kanan, lebar 0,9 meter.
- Jendela 150 × 120 cm di dinding panjang (dinding kanan).
- Tanaman di sudut kiri bawah.

## 3. Daftar isi kafe — 8 bagian

| Bagian | Ukuran (meter) | Letak | Warna awal | Pilihan ganti warna |
|---|---|---|---|---|
| Dinding + lantai | 6 × 4, tinggi 3 | ruangan | Dinding putih, lantai kayu muda | Krem, cokelat muda, hijau sage |
| Counter | 2,5 × 0,6, tinggi 1,1 | dinding belakang | Kayu cokelat | Cokelat tua, hitam, putih |
| Papan menu | 1,5 × 0,8 | dinding belakang di atas counter | Hitam, tulisan putih | — (tidak diganti) |
| Meja (3 buah) | 0,8 × 0,8, tinggi 0,75 | tengah ruangan | Kayu cokelat | Hitam, putih |
| Kursi (6 buah) | 0,45 × 0,45, tinggi 0,9 | di sekeliling meja | Kayu cokelat | Hitam, putih |
| Pintu | 0,9 × 2,1 | dinding bawah | Putih | — (tidak diganti) |
| Jendela | 1,5 × 1,2 | dinding panjang | Kaca bening | — (tidak diganti) |
| Tanaman | 0,4 × 0,4, tinggi 1,0 | sudut kiri bawah | Hijau | — (tidak diganti) |

Total: **8 bagian: dinding + lantai, counter, papan menu, meja, kursi, pintu, jendela, dan tanaman.** Satu ruangan terbuka — tidak ada kamar terpisah, tidak ada atap miring, tidak ada tiang.

## 4. Yang bisa dilakukan pengguna di dalam VR

Ini sudah ada di rencana langkah 29 (script `GantiWarna.cs` dan
`PindahPerabot.cs`), tinggal diisi dengan kafe ini:

1. **Ganti warna dinding** — tap dinding, pilih krem / cokelat muda / hijau sage.
2. **Ganti warna counter** — tap counter, pilih cokelat tua / hitam / putih.
3. **Pindah meja & kursi** — pilih meja, tap titik baru di lantai.
4. **Coba susunan meja** — pilih preset: 3 meja pisah (awal) / 1 meja besar di tengah / 2 meja di sisi jendela.
5. **Jalan keliling** — teleport ke 3 titik: dekat pintu, dekat counter, dekat meja. Di HP, geraknya pakai tombol di layar.
6. **Tombol Reset** — kembali ke warna dan letak awal.

Di video demo nanti, urutannya: letakkan miniatur kafe di meja (AR) →
tekan tombol "Masuk VR" → masuk kafe → ganti warna dinding →
pindah meja → coba susunan meja lain → tekan Reset.

## 5. Yang boleh diikuti dari video tutorial, dan yang harus buatan sendiri

**Boleh diikuti persis (cara umum, bukan plagiarisme):**
cara pasang AR Foundation, tap-to-place, teleport, dan grab dari
video yang sudah diberikan (AR Foundation Tap to Place, AR Furniture,
seri Valem VR).

**Model kafe di-download (boleh, dengan syarat):**
model 3D dari Sketchfab, lisensi CC0 atau CC BY, nama pembuat + lisensi +
link dicantumkan di laporan bagian "Referensi & Lisensi Aset" dan di README.

**Harus buatan kelompok sendiri:**
penempatan AR, tombol transisi, interaksi VR (ganti warna, pindah meja,
susunan meja), UI, urutan demo, video, dan laporan. Kalau semua itu sama
persis dengan video tutorial, nilainya bisa 0 (aturan plagiarisme di PPTX).

## 6. Pembagian kerja (kalau anggota tetap 3 orang)

Brief wajib mencantumkan 10 peran. Dengan 3 anggota, satu orang memegang
beberapa peran. Ini contoh saja — kelompok yang menentukan akhirnya:

- **Alifa:** Project Leader + Lead Developer + VR Specialist + DevOps/Cloud
- **Fauzhira:** AR Specialist + 3D Artist
- **Fadhilah:** UI/UX Designer + QA/Tester + Documentation
- **Presenter/Demo:** bergiliran — Alifa (arsitektur), Fauzhira (AR), Fadhilah (VR + demo)

Pembagian ini disamakan dengan rencana pada 16 Nov 2026 (sebelumnya di denah ini
Lead Developer tertulis di Fadhilah — sudah diperbaiki: Lead Developer tetap
Alifa karena dia yang paling paham Unity dan integrasi).

Kalau anggota UAS ternyata bukan 3 orang ini, pembagian di atas
disesuaikan lagi — kabari saja siapa saja anggotanya.

## 7. Langkah selanjutnya

1. Cari & download model kafe di Sketchfab (ikuti tutorial download).
2. Import model ke Unity, cek bagian-bagiannya terpisah (langkah 17 tutorial).
3. Mulai Fase 1 (setup Unity) dan Fase 2 (aset kafe) di rencana.

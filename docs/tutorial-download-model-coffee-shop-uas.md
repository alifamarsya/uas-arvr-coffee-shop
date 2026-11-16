# Tutorial: Download Model Coffee Shop 3D dari Sketchfab untuk UAS DESAIN AR VR

**Keputusan kelompok (16 Nov 2026): model coffee shop di-download dari Sketchfab, bukan dibangun dari kotak.**
Yang dibangun sendiri: penempatan AR, tombol transisi, interaksi VR, UI, video demo, laporan.
Yang di-download: kafe 3D-nya saja.

**Yang dibutuhkan:** laptop + internet, akun Sketchfab gratis, project Unity 2022.3 LTS (sudah dibuat di Fase 1 rencana).

---

## Bagian A — Cari model kafe yang tepat

1. Buka **sketchfab.com** di browser, buat akun gratis (atau login kalau sudah punya). Download hanya bisa kalau sudah login.
2. Di kolom pencarian, ketik: **`Low Poly Coffee Shop`** (atau `Cafe Interior` / `Coffee Shop`).
3. Centang filter **Downloadable** (hanya model yang boleh di-download). Kalau tidak ada tombol Download di halaman model, berarti pembuatnya melarang download — jangan pakai cara lain untuk mengambilnya, cari model lain.
4. Klik satu model, lalu cek 4 hal ini **sebelum download**:
   - **Lisensi:** tertulis di bawah nama model. Pilih yang **`CC0`** (bebas, tanpa atribusi) atau **`CC BY`** (bebas, wajib mencantumkan nama pembuat). Hindari `CC BY-ND` (dilarang mengubah model) dan `CC BY-NC` kalau ragu — yang paling aman CC0 atau CC BY.
   - **Low poly:** cari kata "low poly" di judul/deskripsi. Untuk HP, usahakan total segitiga (triangles) di bawah 50 ribu — makin kecil makin ringan, makin mulus jalannya di HP.
   - **Satu ruangan saja:** pilih kafe tunggal (satu ruangan, ada counter, meja, dan kursi — mirip denah di `Denah_Coffee_Shop_UAS.md`: 6 × 4 meter). Bukan satu deret toko atau satu mall.
   - **Putar preview 3D-nya:** seret modelnya untuk melihat dari semua sisi — counter, meja, kursi, pintu, jendela lengkap dan tidak ada bagian yang hilang. Usahakan modelnya ada interior yang bisa dimasuki, bukan cuma tampak luar.
5. Kalau sudah cocok, **catat dulu** (untuk laporan nanti): nama model, nama pembuat (author), lisensi, dan link halaman Sketchfab-nya.

## Bagian B — Download modelnya

6. Di halaman model, klik tombol **Download 3D Model**.
7. Pilih format **`.fbx`** — ini format paling aman untuk Unity (langsung bisa di-import). Jangan pilih `.glb`/`.gltf` dulu, karena Unity tidak bisa import format itu tanpa package tambahan.
8. File yang ter-download biasanya berupa **.zip** — ekstrak (klik kanan → Extract) sampai dapat file **.fbx** dan folder **textures** (berisi gambar-gambar tekstur). Simpan keduanya di satu folder yang sama, jangan dipisah.

## Bagian C — Masukkan ke Unity

9. Buka project Unity kalian (2022.3 LTS).
10. Di jendela **Project**, buat folder baru: klik kanan di `Assets` → Create → Folder → beri nama **`Models`**, lalu di dalamnya buat folder **`Kafe`**.
11. **Drag file .fbx dan folder textures** dari File Explorer ke folder `Assets/Models/Kafe` di Unity. Tunggu sampai proses import selesai (ada bar loading di bawah).
12. Klik file **.fbx** di Project → jendela **Inspector** → tab **Model** → cek **Scale Factor**:
    - Kalau angkanya 1, biasanya sudah benar (1 unit Unity = 1 meter).
    - Kalau kafenya kelihatan raksasa/kecil sekali di preview, ubah Scale Factor (misalnya jadi 0.01 atau 100) sampai ukurannya masuk akal, lalu klik **Apply**.
13. Masih di Inspector file .fbx → tab **Materials** → klik **Extract Materials** (supaya materialnya bisa diedit), simpan di folder yang sama.
14. **Kalau kafenya jadi warna pink** (pink = material hilang/rusak): pilih semua material hasil extract → di Inspector, ubah **Shader** menjadi **Universal Render Pipeline → Lit**. Pink-nya hilang dan teksturnya muncul lagi.

## Bagian D — Cek ukuran dan bagian-bagian model

15. **Drag model .fbx dari Project ke Scene** (scene ARScene dulu). Kafe muncul sebagai GameObject bernama sesuai file-nya.
16. Cek ukuran: di Scene, 1 kotak grid = 1 meter. Kafe kecil seharusnya sekitar **6 meter lebarnya** (sesuai denah). Kalau jauh dari itu, ubah Scale Factor lagi (langkah 12).
17. **Cek bagian-bagiannya (ini penting):** di jendela **Hierarchy**, klik segitiga kecil di samping nama kafe untuk membuka isinya.
    - **Bagus:** isinya ada bagian terpisah, misalnya `Wall`, `Counter`, `Table`, `Chair`, `Door`. Artinya tiap bagian bisa diganti warna atau dipindah sendiri — fitur kustomisasi (ganti warna dinding/counter, pindah meja & kursi) bisa jalan.
    - **Kurang bagus:** isinya cuma satu mesh utuh (misalnya hanya `Cafe` saja, tidak bisa dibuka). Artinya dinding dan perabot menyatu — tidak bisa ganti warna satu dinding saja. Kalau ini yang terjadi, pilihannya: (a) cari model lain yang bagiannya terpisah, atau (b) kustomisasi dibatasi ke bagian yang terpisah saja (misalnya hanya ganti warna counter kalau counternya terpisah).
18. Kalau modelnya bagus, **jangan ubah bentuknya** — cukup atur posisi dan ukuran.

## Bagian E — Pasang di dua scene (AR dan VR)

19. **Di ARScene (miniatur):** model yang sama dipakai sebagai miniatur di atas meja/lantai. Atur **Scale** GameObject kafe di Inspector supaya miniaturnya sekitar **40 cm**: rumusnya `0,4 ÷ lebar kafe (meter)`. Contoh: kafe 6 meter → Scale **0,06** (0,06, 0,06, 0,06). Miniatur ini yang muncul saat tap-to-place (tutorial Tap to Place).
20. **Di VRScene (ukuran asli):** drag model yang sama ke scene VR → atur **Scale 1, 1, 1** (ukuran asli) → posisikan di lantai (Position Y = 0, kafe berdiri di atas lantai, tidak melayang dan tidak tenggelam). Lalu pasang **XR Origin** (kamera VR) + **Teleportation Area** di lantai kafe, supaya pengguna bisa jalan/teleport di dalamnya.
21. Simpan kedua scene (Ctrl+S). Test di HP (Galaxy A23): AR muncul miniaturnya, tombol "Masuk VR" pindah ke VR, di VR bisa jalan keliling.

## Bagian F — Catat lisensi untuk laporan

22. Tulis di laporan bagian **"Referensi & Lisensi Aset"** dan di README, dengan format ini:

> Model coffee shop 3D: "[Nama Model]" oleh [Nama Pembuat], lisensi [CC0 / CC BY], diunduh dari [link Sketchfab].

Contoh: Model coffee shop 3D: "Low Poly Coffee Shop" oleh JohnDoe, lisensi CC BY, diunduh dari sketchfab.com/3d-models/low-poly-coffee-shop-xxxx.

---

## Kalau ada masalah (troubleshooting)

| Masalah | Penyebab | Perbaikan |
|---|---|---|
| Tidak ada tombol Download | Pembuat melarang download | Cari model lain, jangan pakai downloader pihak ketiga |
| File .glb tidak bisa di-import Unity | Unity tidak bisa baca .glb tanpa package tambahan | Download ulang sebagai .fbx |
| Kafe jadi warna pink | Shader tidak cocok / material hilang | Ubah Shader material ke URP → Lit (langkah 14) |
| Kafe terlalu besar/kecil | Scale Factor salah | Ubah Scale Factor di tab Model, klik Apply (langkah 12) |
| Tekstur hilang (dinding polos putih) | Folder textures tidak ikut ke-drag | Drag folder textures ke folder yang sama dengan .fbx, lalu reimport |
| HP lag / patah-patah saat jalan di VR | Model terlalu berat (triangles besar) | Cari model low poly lain (di bawah 50 ribu triangles) |
| Tidak bisa ganti warna satu dinding | Model satu mesh utuh | Cari model lain yang bagiannya terpisah (langkah 17) |

---

*Dibuat 16 November 2026 (diubah dari tutorial model rumah ke tema Coffee Shop). Fakta dicek lewat pencarian web 16 Nov 2026: download gratis Sketchfab butuh akun; format download termasuk FBX, glTF/GLB, OBJ, USDZ, STL; lisensi per model CC0 / CC BY / CC BY-SA / CC BY-NC / CC BY-ND / Standard — CC BY wajib atribusi, CC0 tidak; model tanpa tombol Download berarti dilarang di-download.*

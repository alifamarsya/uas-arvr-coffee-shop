# Tutorial Lengkap UAS — Coffee Shop AR + VR (Satu File untuk Bertiga)

**Tema: Coffee Shop (kafe) · Metode: Kelompok 2 — Ground Plane (AR) + Room-Scale (VR)**
**Alat: Unity 2022.3 LTS · AR Foundation + ARCore XR Plugin · OpenXR + XR Interaction Toolkit**
**Dosen: Fizar Syafa'at · HP uji: Galaxy A23 (punya ARCore + giroskop; Galaxy A15 TIDAK bisa untuk VR)**

## Pembagian peran (10 peran wajib PPTX, dibagi ke 3 orang)

PPTX mewajibkan 10 peran dicantumkan di laporan. Pembagian di bawah ini sudah
disamakan dengan file rencana dan denah (16 Nov 2026):

| Peran (PPTX) | Penanggung jawab |
|---|---|
| Project Leader | **Alifa** |
| Lead Developer | **Alifa** |
| AR Specialist | **Fauzhira** |
| VR Specialist | **Alifa** |
| UI/UX Designer | **Fadhilah** |
| 3D Artist | **Fauzhira** |
| QA/Tester | **Fadhilah** |
| DevOps/Cloud | **Alifa** |
| Documentation | **Fadhilah** |
| Presenter/Demo | **Bergiliran** — Alifa (arsitektur & tools), Fauzhira (demo AR), Fadhilah (demo VR + alur) |

## Cara pakai file ini

- Tiap orang baca **Bagian 0** dulu (persiapan bersama), lalu kerjakan **Bagiannya sendiri** sesuai urutan langkah.
- Tanda **🔄** = serah terima ke teman. Jangan lanjut ke langkah itu sebelum temanmu selesai menyerahkan.
- Tanda **✅** = cek hasil. Kalau hasilnya tidak sesuai, jangan lanjut dulu. Perbaiki atau tanya ke teman.
- Semua langkah ditulis berurutan. Nomor langkahnya nyambung dari Bagian 0 sampai Bagian 4, supaya kalau ada yang bertanya "kamu sudah sampai langkah berapa?", jawabannya jelas.

## Timeline (6 minggu) — siapa mengerjakan apa

| Minggu | Alifa | Fauzhira | Fadhilah |
|---|---|---|---|
| 1 | Buat repo GitHub + setup project Unity | Cari & download model kafe | Sketsa UI (menu, panel info, panel kustomisasi) |
| 2 | GameManager + tombol transisi | Import model + prefab Kafe_Mini & Kafe_Full 🔄 | Buat menu awal + panel info |
| 3 | Scene VR + XR Origin + teleport | Scene AR lengkap (placement, reticle, tombol) | Panel kustomisasi + audio |
| 4 | Kustomisasi VR + gyro + walkthrough PC | Polish AR + bantu uji | Bantu uji + siapkan lembar uji usability & SSQ |
| 5 | Build APK final 🔄 | Perbaiki bug AR | Uji usability + SSQ + bug log 🔄 |
| 6 | Gladi + cadangan demo | Gladi + presentasi AR | Laporan + slide + video (bareng) + presentasi VR |

---

## Bagian 0 — Persiapan bersama (semua orang, Minggu 1)

### Langkah 1 — Install Unity 2022.3 LTS (tiap orang di laptop masing-masing)

1. Buka **Unity Hub**. Kalau belum punya, download di unity.com lalu install.
2. Di Unity Hub, klik tab **Installs** → tombol **Install Editor**.
3. Pilih versi **2022.3 LTS** (misalnya 2022.3.62f3 — versi yang sama dengan project AR kemarin).
4. Di daftar modul, centang: **Android Build Support**, **Android SDK & NDK Tools**, **OpenJDK**. (Tanpa tiga ini, project tidak bisa di-build ke HP Android.)
5. Klik **Install** dan tunggu sampai selesai (bisa 30–60 menit, tergantung internet).
6. ✅ Cek hasil: di tab Installs muncul "2022.3.62f3" (atau nomor 2022.3 lainnya) dengan tulisan Android di sampingnya.

### Langkah 2 — Siapkan akun GitHub (tiap orang)

1. Buka **github.com**, buat akun gratis kalau belum punya (atau login).
2. Install **GitHub Desktop** (desktop.github.com) — ini cara paling gampang untuk download (clone) dan upload (commit/push) project tanpa hafal perintah Git.
3. Login GitHub Desktop dengan akunmu.

### Langkah 3 — HP uji (cek sekali, di awal)

1. HP yang dipakai untuk semua pengujian: **Galaxy A23** (punya ARCore + giroskop).
2. Aktifkan **USB debugging** di A23: buka Settings → About phone → ketuk **Build number** 7 kali sampai muncul "You are now a developer" → kembali ke Settings → Developer options → nyalakan **USB debugging**.
3. **Galaxy A15 jangan dipakai untuk VR** — tidak punya giroskop, jadi mode VR tidak jalan.

### Langkah 4 — Aturan kerja bareng (disepakati bertiga, jangan dilanggar)

1. **Pull dulu sebelum mulai kerja tiap hari:** di GitHub Desktop, klik **Fetch origin** → **Pull origin**. Ini mengambil kerja terbaru temanmu supaya tidak bentrok.
2. **Commit setelah tiap langkah selesai:** tulis pesan commit yang jelas, contoh: `[Fauzhira] Import model kafe + prefab Kafe_Mini`. Jangan commit dengan pesan "update" saja.
3. **Jangan edit scene atau file teman tanpa bilang dulu.** Kalau harus menyentuh, kabari di grup.
4. **Semua aset dari luar dicatat lisensinya** (nama aset, pembuat, lisensi, link) — nanti masuk laporan dan README.
5. **Fitur dibekukan akhir Minggu 4.** Setelah itu hanya perbaikan bug, tidak tambah fitur baru.

---

## Bagian 1 — ALIFA (Project Leader + Lead Developer + VR Specialist + DevOps/Cloud)

### 1A. Project Leader — Langkah 5–7

#### Langkah 5 — Buat repo GitHub (Minggu 1)

1. Buka **github.com** → klik **+** di kanan atas → **New repository**.
2. Repository name: **`uas-arvr-coffee-shop`**. Pilih **Public** atau **Private** (ikut aturan dosen; kalau ragu, pilih Private).
3. Centang **Add a README file**. Klik **Create repository**.
4. Undang Fauzhira dan Fadhilah: di repo, klik **Settings** → **Collaborators** → **Add people** → masukkan username GitHub mereka → **Add**.
5. ✅ Cek hasil: mereka bisa membuka repo dan namanya muncul di daftar Collaborators.

#### Langkah 6 — Buat struktur folder repo (Minggu 1)

1. Di GitHub Desktop, **Clone** repo `uas-arvr-coffee-shop` ke laptopmu.
2. Di dalam folder repo, buat folder-folder ini: **`/src`**, **`/assets`**, **`/build`**, **`/docs`**, **`/demo`**.
3. Nanti isinya: `/src` = project Unity; `/assets` = model 3D + tekstur + file lisensi; `/build` = APK; `/docs` = laporan + slide; `/demo` = video demo.
4. Commit dengan pesan: `[Alifa] Struktur folder repo awal`. Klik **Push origin**.
5. Kabari Fauzhira dan Fadhilah untuk clone repo ini (GitHub Desktop → Clone a Repository → pilih repo ini).

#### Langkah 7 — Jadwal & rapat mingguan (Minggu 1–6)

1. Buat jadwal di grup (chat/WA): tiap Minggu malam, rapat singkat 15 menit. Tiap orang jawab 3 hal: apa yang selesai minggu ini, apa yang macet, apa yang dikerjakan minggu depan.
2. Catat keputusan rapat (misalnya "tema final Coffee Shop", "model download dari Sketchfab") di README repo supaya tidak lupa.
3. **Akhir Minggu 4: bekukan fitur.** Setelah itu tidak ada fitur baru, hanya perbaikan bug.

### 1B. Lead Developer — Setup project Unity, Langkah 8–12

#### Langkah 8 — Buat project Unity baru (Minggu 1)

1. Buka **Unity Hub** → **New project**.
2. Pilih template **3D (URP)**. (URP = Universal Render Pipeline, template grafis yang ringan untuk HP.)
3. Project Name: **`VRGroundPlaneRoomScale`**. Location: di dalam folder **`/src`** repo (jadi path-nya `uas-arvr-coffee-shop/src/VRGroundPlaneRoomScale`).
4. Klik **Create project** dan tunggu sampai Unity terbuka.
5. ✅ Cek hasil: Unity terbuka, di jendela Hierarchy ada Main Camera dan Directional Light.

#### Langkah 9 — Pindah platform ke Android (Minggu 1)

1. Di Unity, klik menu **File → Build Settings**.
2. Di daftar Platform, klik **Android** → klik tombol **Switch Platform**. Tunggu sampai selesai (bisa beberapa menit).
3. ✅ Cek hasil: di samping Android muncul logo Unity kecil (tanda platform aktif).

#### Langkah 10 — Install package yang dibutuhkan (Minggu 1)

1. Buka **Window → Package Manager**.
2. Di kiri atas Package Manager, pilih **Packages: Unity Registry**.
3. Cari dan install satu per satu (ketik nama di kolom Search, klik package-nya, klik **Install**, tunggu sampai selesai):
   - **AR Foundation**
   - **ARCore XR Plugin**
   - **XR Plugin Management**
   - **OpenXR Plugin**
   - **XR Interaction Toolkit**
4. Kalau ada yang minta install package lain sebagai syarat (dependency), klik **Install** juga.
5. ✅ Cek hasil: kelima package muncul dengan status ter-install (tidak ada tombol Install lagi).

#### Langkah 11 — Nyalakan ARCore dan OpenXR (Minggu 1)

1. Buka **Edit → Project Settings → XR Plug-in Management**.
2. Klik tab **Android** (di atas).
3. Di **Plug-in Providers**, centang **ARCore** dan **OpenXR**.
4. Klik **OpenXR** di menu kiri (di bawah XR Plug-in Management) → tab **Android** → di **Interaction Profiles**, klik **+** → tambahkan **Eye Gaze Interaction Profile**? Tidak perlu. Lewati saja bagian ini kalau tidak ada yang wajib diisi.
5. ✅ Cek hasil: ARCore dan OpenXR sama-sama tercentang di tab Android.

#### Langkah 12 — Atur Player Settings (Minggu 1)

1. Buka **Edit → Project Settings → Player**. Pastikan tab **Android** yang aktif (ikon Android di atas).
2. **Other Settings → Identification → Package Name:** isi **`com.kelompok4.vrgroundplane`**.
3. **Other Settings → Identification → Minimum API Level:** pilih **Android 6.0 'Marshmallow' (API level 26)**.
4. **Other Settings → Configuration → Scripting Backend:** pilih **IL2CPP**. (Pelajaran dari project kemarin: Mono membuat ARM64 tidak bisa dicentang.)
5. **Other Settings → Configuration → Target Architectures:** centang **ARM64** saja, **hapus centang ARMv7**.
6. **Other Settings → Rendering → Graphics APIs:** hapus **Vulkan** dari daftar (klik Vulkan → tombol **-**), sisakan **OpenGLES3** saja. (Zappar/AR tidak cocok dengan Vulkan; OpenGLES3 paling aman.)
7. Tutup Project Settings. **Commit pertama:** pesan `[Alifa] Project Unity kosong + Player Settings Android`. Push.
8. ✅ Cek hasil: project bisa di-build kosong tanpa error (coba File → Build Settings → Build, tunggu sampai APK jadi — boleh dibatalkan setelah terbukti jalan, atau lanjutkan sampai APK selesai lalu hapus APK-nya).

### 1C. Lead Developer — GameManager & transisi, Langkah 13–15

#### Langkah 13 — Buat script GameManager (Minggu 2)

1. Di jendela **Project**, klik kanan di folder **Assets** → **Create → Folder** → beri nama **`Scripts`**.
2. Klik kanan di folder **Scripts** → **Create → C# Script** → beri nama **`GameManager`**.
3. Klik dua kali file `GameManager` — terbuka di editor kode (Visual Studio / VS Code).
4. Hapus semua isi file, lalu ketik kode ini persis:

```csharp
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string namaModel = "Kafe";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PindahKeVR()
    {
        SceneManager.LoadScene("VRScene");
    }

    public void PindahKeAR()
    {
        SceneManager.LoadScene("ARScene");
    }
}
```

5. Simpan file (Ctrl+S) dan kembali ke Unity. Tunggu Unity selesai compile (tidak ada error merah di Console).
6. **Apa arti kode ini (supaya bisa dijelaskan ke dosen):** `DontDestroyOnLoad` artinya GameObject ini tidak dihapus saat pindah scene, jadi data yang disimpan di sini (misalnya nama model) tetap ada dari AR ke VR. `PindahKeVR` dan `PindahKeAR` adalah perintah pindah scene yang nanti dipanggil tombol.
7. ✅ Cek hasil: di Console (Window → General → Console) tidak ada error merah.

#### Langkah 14 — Pasang GameManager di scene (Minggu 2)

1. Buka scene **ARScene** (dibuat Fauzhira di Bagian 2 — kalau belum ada, buat dulu: File → New Scene → simpan sebagai `ARScene` di folder `Assets/Scenes`).
2. Di Hierarchy, klik kanan → **Create Empty** → beri nama **`GameManager`**.
3. Pilih GameObject `GameManager` → di Inspector klik **Add Component** → ketik **GameManager** → pilih script-nya.
4. Ulangi langkah 2–3 di scene **VRScene** juga (GameObject yang sama namanya; script-nya akan menghapus duplikatnya sendiri saat pindah scene, jadi aman).
5. Simpan kedua scene (Ctrl+S).

#### Langkah 15 — Sambung tombol "Masuk VR" dan "Kembali ke AR" (Minggu 2)

1. Di **ARScene**, pilih tombol **"Masuk VR"** (dibuat Fadhilah di Bagian 3 — kalau belum ada, minta Fadhilah buatkan dulu).
2. Di Inspector tombol, cari bagian **On Click ()** → klik **+** → drag GameObject **`GameManager`** dari Hierarchy ke kotak yang kosong.
3. Di dropdown yang muncul, pilih **GameManager → PindahKeVR()**.
4. Di **VRScene**, pilih tombol **"Kembali ke AR"** → On Click (+) → drag `GameManager` → pilih **GameManager → PindahKeAR()**.
5. ✅ Cek hasil: tekan Play di Unity, klik tombol "Masuk VR" → scene berganti ke VRScene. Klik "Kembali ke AR" → kembali ke ARScene. Kalau tidak berganti, cek: (a) nama scene di kode sama persis dengan nama file scene (`VRScene` dan `ARScene`), (b) kedua scene sudah ditambahkan ke Build Settings (File → Build Settings → klik **Add Open Scenes** saat tiap scene terbuka).

### 1D. VR Specialist — Scene VR, Langkah 16–22

#### Langkah 16 — Buat scene VRScene dan pasang XR Origin (Minggu 3)

1. Buat scene baru: **File → New Scene** → simpan dengan **File → Save As** → folder `Assets/Scenes` → nama **`VRScene`**.
2. Hapus **Main Camera** bawaan (klik kanan Main Camera di Hierarchy → Delete). Kamera VR nanti datang dari XR Origin.
3. Pasang XR Origin: klik menu **GameObject → XR → XR Origin** (pilih yang **Action-based**; kalau di versimu ada pilihan **Room-Scale**, pilih itu — sama saja).
4. Pilih GameObject **XR Origin** di Hierarchy → di Inspector, cari komponen **XR Origin** → **Tracking Origin Mode** → pilih **Floor**. (Floor artinya titik nol ada di lantai, jadi tinggi kamera diukur dari lantai — ini yang membuat VR terasa room-scale.)
5. Masih di komponen XR Origin, cari **Camera Y Offset** → isi **1.6**. (Di HP tidak ada pelacak kepala, jadi tinggi kamera diatur manual: 1.6 meter = tinggi mata orang berdiri.)
6. ✅ Cek hasil: tekan Play — di Game View kamu melihat dari ketinggian 1.6 meter di atas lantai.

#### Langkah 17 — Pasang replika kafe skala 1:1 (Minggu 3)

1. 🔄 **Tunggu Fauzhira:** prefab `Kafe_Full` harus sudah ada (Langkah 33).
2. Di Project, cari prefab **`Kafe_Full`** → drag ke Hierarchy VRScene.
3. Pilih prefab itu → di Inspector, **Position** = (0, 0, 0), **Rotation** = (0, 0, 0), **Scale** = (1, 1, 1).
4. Pastikan kafe berdiri di atas lantai (Position Y = 0, tidak melayang dan tidak tenggelam).
5. Tambahkan lantai kalau model tidak punya lantai sendiri: Hierarchy → klik kanan → **3D Object → Plane** → Scale (10, 1, 10) → Position (0, 0, 0).
6. Tambahkan pencahayaan: pastikan ada **Directional Light** (kalau tidak ada, Hierarchy → klik kanan → Light → Directional Light) dan atur Rotation X = 50 supaya bayangan jatuh miring seperti matahari siang.
7. Simpan scene (Ctrl+S).

#### Langkah 18 — Pasang Locomotion & Teleportation (Minggu 3)

1. Pasang Locomotion System: klik menu **GameObject → XR → Locomotion System**. (GameObject ini mengatur semua cara bergerak di VR.)
2. Pilih GameObject **Locomotion System** → di Inspector klik **Add Component** → ketik **Teleportation Provider** → pilih.
3. Buat area teleport: pilih lantai (Plane dari Langkah 17, atau lantai kafe) → di Inspector klik **Add Component** → ketik **Teleportation Area** → pilih. (Area ini menandai lantai mana saja yang boleh di-teleport.)
4. Buat 3 titik teleport (anchor): di Hierarchy, klik kanan → **Create Empty** → beri nama **`TitikPintu`** → posisikan di dekat pintu (misalnya Position (0, 0, 1.5)) → Add Component → **Teleportation Anchor**. Ulangi untuk **`TitikCounter`** (dekat counter, misalnya (-1.5, 0, -1)) dan **`TitikMeja`** (dekat meja, misalnya (1.5, 0, 0.5)).
5. ✅ Cek hasil: di Scene View, lantai dan ketiga titik menampilkan gizmo teleport (lingkaran/panah kecil).

#### Langkah 19 — Tombol teleport untuk HP (Minggu 3)

Di HP tidak ada controller VR, jadi teleport dilakukan lewat tombol di layar. (Teleportation Area di Langkah 18 tetap dipasang untuk nanti kalau dicoba di Quest.)

1. Buat script baru di folder **Scripts** → beri nama **`TeleportTombol`**. Isi kodenya:

```csharp
using UnityEngine;

public class TeleportTombol : MonoBehaviour
{
    public Transform xrOrigin;     // drag XR Origin ke sini
    public Transform titikTujuan;  // drag titik (TitikPintu / TitikCounter / TitikMeja) ke sini

    public void Pindah()
    {
        Vector3 posisiBaru = titikTujuan.position;
        posisiBaru.y = xrOrigin.position.y; // jangan ubah tinggi kamera
        xrOrigin.position = posisiBaru;
    }
}
```

2. Simpan (Ctrl+S), kembali ke Unity.
3. Buat 3 tombol di UI VR (Fadhilah yang membuat tombolnya — lihat Bagian 3): **"Ke Pintu"**, **"Ke Counter"**, **"Ke Meja"**.
4. Untuk tiap tombol: buat GameObject kosong baru (misalnya `TeleportPintu`) → Add Component → **TeleportTombol** → drag **XR Origin** ke kolom `xrOrigin` → drag titik yang sesuai (misalnya `TitikPintu`) ke kolom `titikTujuan` → lalu di tombol, On Click (+) → drag GameObject `TeleportPintu` → pilih **TeleportTombol → Pindah()**.
5. ✅ Cek hasil: tekan Play → klik tombol "Ke Counter" → kamera pindah ke dekat counter. Klik "Ke Pintu" → kamera pindah ke dekat pintu.

#### Langkah 20 — Kamera mengikuti giroskop HP, "jendela ajaib" (Minggu 4)

1. Buat script baru di folder **Scripts** → beri nama **`KameraGiroskop`**. Isi kodenya:

```csharp
using UnityEngine;

public class KameraGiroskop : MonoBehaviour
{
    void Start()
    {
        Input.gyro.enabled = true;
    }

    void Update()
    {
        Quaternion gyro = Input.gyro.attitude;
        transform.localRotation = new Quaternion(gyro.x, gyro.y, -gyro.z, -gyro.w);
    }
}
```

2. Simpan (Ctrl+S), kembali ke Unity.
3. Pilih **Main Camera** yang ada di dalam **XR Origin** (buka segitiga XR Origin di Hierarchy → Camera Offset → Main Camera) → Add Component → **KameraGiroskop**.
4. **Arti kode ini (untuk dijelaskan ke dosen):** `Input.gyro.attitude` membaca sensor giroskop HP (sensor yang tahu HP dimiringkan ke mana). Script ini memutar kamera mengikuti gerakan HP, jadi gerakkan HP ke kiri/kanan/atas/bawah untuk melihat sekeliling — seperti mengintip lewat jendela.
5. ✅ Cek hasil: build ke HP (Langkah 27) → buka mode VR → gerakkan HP → pandangan ikut bergerak. Kalau pandangan terbalik/miring, balik tanda minus di kode (coba `-gyro.z` jadi `gyro.z`, atau sebaliknya) lalu build ulang. Catat versi yang benar.

#### Langkah 21 — Fitur kustomisasi: ganti warna dinding & counter (Minggu 4)

1. Buat script baru di folder **Scripts** → beri nama **`GantiWarna`**. Isi kodenya:

```csharp
using UnityEngine;

public class GantiWarna : MonoBehaviour
{
    public Renderer dinding;
    public Renderer counter;
    public Renderer meja;
    private Renderer bagianTerpilih;
    private Color warnaAwalDinding, warnaAwalCounter, warnaAwalMeja;

    void Start()
    {
        bagianTerpilih = dinding;
        warnaAwalDinding = dinding.material.color;
        warnaAwalCounter = counter.material.color;
        warnaAwalMeja = meja.material.color;
    }

    public void PilihDinding() { bagianTerpilih = dinding; }
    public void PilihCounter() { bagianTerpilih = counter; }
    public void PilihMeja() { bagianTerpilih = meja; }

    public void GantiKeWarna(Color warnaBaru)
    {
        if (bagianTerpilih != null)
            bagianTerpilih.material.color = warnaBaru;
    }

    public void ResetWarna()
    {
        dinding.material.color = warnaAwalDinding;
        counter.material.color = warnaAwalCounter;
        meja.material.color = warnaAwalMeja;
    }
}
```

2. Simpan (Ctrl+S), kembali ke Unity.
3. Buat GameObject kosong **`PengaturWarna`** di VRScene → Add Component → **GantiWarna**.
4. 🔄 **Butuh nama bagian dari Fauzhira:** di Hierarchy VRScene, buka isi prefab `Kafe_Full` (klik segitiga di sampingnya) → cari child object dinding, counter, dan meja → drag masing-masing ke kolom `dinding`, `counter`, `meja` di Inspector `PengaturWarna`. (Ini hanya bisa kalau bagian model terpisah — Fauzhira sudah cek di Langkah 31.)
5. **Catatan penting:** `.material` membuat salinan material, jadi yang berubah warnanya hanya bagian itu saja, bukan semua objek yang memakai material yang sama. Kalau dindingnya bertekstur, warna yang dipilih akan mencampur teksturnya — itu normal.
6. Sambung ke tombol UI (Fadhilah yang membuat panelnya — lihat Bagian 3): tombol **"Dinding"** → On Click → `PengaturWarna` → **GantiWarna → PilihDinding()**; tombol **"Counter"** → **PilihCounter()**; tombol **"Meja"** → **PilihMeja()**. Tombol warna (misalnya "Krem") → **GantiKeWarna()** → klik kotak warnanya di Inspector lalu pilih warna krem. Tombol **"Reset"** → **ResetWarna()**.
7. ✅ Cek hasil: tekan Play → klik "Dinding" → klik warna "Krem" → dinding berubah krem. Klik "Reset" → warna kembali seperti awal.

#### Langkah 22 — Fitur kustomisasi: pindah meja & susunan meja (Minggu 4)

1. **Siapkan layer lantai dulu:** pilih lantai kafe → di Inspector, klik dropdown **Layer** (kanan atas) → **Add Layer...** → di **User Layer 8**, ketik **`Lantai`** → kembali ke lantai → Layer → pilih **Lantai**. Pastikan lantai punya **Collider** (komponen Box Collider atau Mesh Collider — kalau belum ada, Add Component → Box Collider, atur ukurannya menutupi lantai).
2. Buat script baru → beri nama **`PindahPerabot`**. Isi kodenya:

```csharp
using UnityEngine;
using UnityEngine.EventSystems;

public class PindahPerabot : MonoBehaviour
{
    public GameObject perabotTerpilih;  // drag meja yang sedang dipilih
    public LayerMask lapisanLantai;     // pilih layer "Lantai" di Inspector

    void Update()
    {
        if (perabotTerpilih == null) return;
        if (EventSystem.current.IsPointerOverGameObject()) return; // tap tombol UI jangan ikut memindah
        if (Input.touchCount == 0 && !Input.GetMouseButtonDown(0)) return;

        Vector3 posisiLayar = Input.touchCount > 0
            ? (Vector3)Input.GetTouch(0).position
            : Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(posisiLayar);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, lapisanLantai))
        {
            Vector3 posisiBaru = hit.point;
            posisiBaru.y = perabotTerpilih.transform.position.y; // jangan ubah tinggi meja
            perabotTerpilih.transform.position = posisiBaru;
        }
    }

    public void PilihPerabot(GameObject perabot)
    {
        perabotTerpilih = perabot;
    }
}
```

3. Simpan (Ctrl+S). Buat GameObject kosong **`PengaturPindah`** → Add Component → **PindahPerabot** → di kolom `lapisanLantai`, centang hanya **Lantai**.
4. Sambung ke tombol UI: tombol **"Pindah Meja 1"** → On Click → `PengaturPindah` → **PindahPerabot → PilihPerabot()** → drag GameObject Meja 1 ke kolom yang muncul. Ulangi untuk Meja 2 dan Meja 3.
5. **Susunan meja (preset):** buat script baru → beri nama **`SusunanMeja`**. Isi kodenya (angka contoh untuk kafe 6 × 4 meter dengan lantai di tengah (0,0) — sesuaikan dengan model download kalian):

```csharp
using UnityEngine;

public class SusunanMeja : MonoBehaviour
{
    public GameObject meja1, meja2, meja3;

    public void SusunanPisah() // 3 meja terpisah (posisi awal)
    {
        meja1.transform.position = new Vector3(-1.5f, 0, 0.5f);
        meja2.transform.position = new Vector3(1.5f, 0, 0.5f);
        meja3.transform.position = new Vector3(0, 0, -1f);
    }

    public void SusunanBesar() // 3 meja dirapatkan jadi 1 meja besar
    {
        meja1.transform.position = new Vector3(-0.9f, 0, 0);
        meja2.transform.position = new Vector3(0, 0, 0);
        meja3.transform.position = new Vector3(0.9f, 0, 0);
    }

    public void SusunanJendela() // 3 meja di sisi jendela
    {
        meja1.transform.position = new Vector3(2f, 0, 1f);
        meja2.transform.position = new Vector3(2f, 0, 0);
        meja3.transform.position = new Vector3(2f, 0, -1f);
    }
}
```

6. Buat GameObject kosong **`PengaturSusunan`** → Add Component → **SusunanMeja** → drag Meja 1, 2, 3 ke kolomnya. Sambung tombol UI: **"3 Meja Pisah"** → SusunanPisah(), **"1 Meja Besar"** → SusunanBesar(), **"Sisi Jendela"** → SusunanJendela().
7. ✅ Cek hasil: tekan Play → klik "1 Meja Besar" → ketiga meja berkumpul di tengah. Klik "Reset" (tombol Reset memanggil SusunanPisah + ResetWarna — sambung keduanya di On Click tombol Reset).

#### Langkah 23 — Mode walkthrough PC, cadangan demo di laptop (Minggu 4)

1. Buat script baru → beri nama **`JalanPC`**. Isi kodenya:

```csharp
using UnityEngine;

public class JalanPC : MonoBehaviour
{
    public float kecepatanJalan = 3f;
    public float kecepatanPutar = 100f;
    private float putarX = 0f;

    void Update()
    {
        float maju = Input.GetAxis("Vertical");       // tombol W / S
        float samping = Input.GetAxis("Horizontal");   // tombol A / D
        Vector3 gerak = transform.TransformDirection(new Vector3(samping, 0, maju));
        transform.position += gerak * kecepatanJalan * Time.deltaTime;

        float mouseX = Input.GetAxis("Mouse X") * kecepatanPutar * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * kecepatanPutar * Time.deltaTime;
        putarX -= mouseY;
        putarX = Mathf.Clamp(putarX, -80f, 80f);
        transform.Rotate(0, mouseX, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(putarX, 0, 0);
    }
}
```

2. Di VRScene, buat GameObject kosong **`PCPlayer`** → Add Component → **JalanPC** → Position (0, 1.6, 2) → buat child Camera di dalamnya (klik kanan PCPlayer → Camera) → Position (0, 0, 0).
3. **Matikan (uncheck) PCPlayer** di Inspector (kotak centang di kiri nama). Nyalakan hanya saat demo di laptop.
4. **Aturan pakai:** demo di HP → XR Origin nyala, PCPlayer mati. Demo di laptop → XR Origin mati (uncheck), PCPlayer nyala. Jangan nyalakan keduanya bersamaan.
5. ✅ Cek hasil: di editor, matikan XR Origin, nyalakan PCPlayer, tekan Play → gerakkan dengan W/A/S/D + mouse → kamera jalan dan melihat sekeliling. Kembalikan seperti semula setelah dites (XR Origin nyala, PCPlayer mati).

### 1E. DevOps/Cloud — Build & serah terima, Langkah 24–27

#### Langkah 24 — Tambahkan scene ke Build Settings (Minggu 2, ulangi tiap ada scene baru)

1. Buka **File → Build Settings**.
2. Buka scene **ARScene** → klik **Add Open Scenes**. Buka scene **VRScene** → klik **Add Open Scenes**.
3. ✅ Cek hasil: di **Scenes In Build** ada ARScene (index 0) dan VRScene (index 1). Kalau urutannya terbalik, drag untuk menukar — ARScene harus nomor 0 karena aplikasi dibuka dari AR dulu.

#### Langkah 25 — Build APK pertama (Minggu 3, coba-coba)

1. Sambungkan HP A23 ke laptop dengan kabel USB. Di HP, izinkan **USB debugging** (muncul pop-up → izinkan).
2. File → Build Settings → pilih **Android** → klik **Build And Run**.
3. Pilih lokasi simpan: folder **`/build`** di repo → nama file **`coffee-shop-arvr.apk`**.
4. Tunggu build selesai (5–15 menit pertama kali). APK otomatis terinstal di HP dan aplikasi terbuka.
5. ✅ Cek hasil: aplikasi terbuka di HP, ARScene muncul, kamera menyala. Kalau build gagal, baca error di Console — yang paling sering: package belum ter-install (Langkah 10) atau Minimum API salah (Langkah 12).

#### Langkah 26 — Upload & catat versi (tiap kali build baru)

1. Simpan APK hasil build ke folder **`/build`** dengan nama berversi, contoh: `coffee-shop-arvr-v1.apk`, `v2`, dan seterusnya.
2. Commit + push APK-nya? APK besar — cukup simpan di `/build` lokal dan upload ke **Google Drive** (buat folder "UAS AR VR — Build"). Tulis di README: versi APK terakhir + tanggal + apa yang berubah.
3. ✅ Cek hasil: siapa pun di kelompok bisa download APK dari Drive dan install di HP bersih (bukan HP developer) lalu aplikasi jalan.

#### Langkah 27 — Serah terima APK ke Fadhilah untuk diuji (Minggu 5) 🔄

1. Build APK final Minggu 5 (Langkah 25–26).
2. Kirim APK + catatan "apa yang baru di versi ini" ke Fadhilah.
3. Fadhilah menguji (Bagian 3) dan mengembalikan daftar bug. Perbaiki bug, build ulang, serahkan lagi sampai Fadhilah menyatakan lolos.

---

## Bagian 2 — FAUZHIRA (AR Specialist + 3D Artist)

### 2A. 3D Artist — Download & siapkan model kafe, Langkah 28–33

#### Langkah 28 — Cari model kafe di Sketchfab (Minggu 1)

1. Buka **sketchfab.com** di browser, login dengan akun gratis (buat dulu kalau belum punya — download hanya bisa kalau sudah login).
2. Di kolom pencarian, ketik: **`Low Poly Coffee Shop`** (alternatif: `Cafe Interior` / `Coffee Shop`).
3. Centang filter **Downloadable** (hanya model yang boleh di-download).
4. Klik satu model, lalu cek 4 hal ini **sebelum download**:
   - **Lisensi:** tertulis di bawah nama model. Pilih **`CC0`** (bebas, tanpa atribusi) atau **`CC BY`** (bebas, wajib mencantumkan nama pembuat). Hindari `CC BY-ND` (dilarang mengubah model).
   - **Low poly:** cari kata "low poly" di judul/deskripsi. Usahakan total segitiga (triangles) di bawah 50 ribu supaya HP tidak lag.
   - **Satu ruangan saja:** pilih kafe tunggal (satu ruangan, ada counter, meja, kursi — mirip denah `Denah_Coffee_Shop_UAS.md`: 6 × 4 meter). Bukan satu deret toko atau satu mall.
   - **Putar preview 3D-nya:** seret modelnya untuk melihat dari semua sisi. Usahakan modelnya ada interior yang bisa dimasuki, bukan cuma tampak luar.
5. Kalau tidak ada tombol Download di halaman model, berarti pembuatnya melarang download — jangan pakai downloader pihak ketiga, cari model lain.
6. **Catat dulu** (untuk laporan nanti): nama model, nama pembuat (author), lisensi, dan link halaman Sketchfab-nya. Kirim catatan ini ke Fadhilah (dia yang menulis laporan).

#### Langkah 29 — Download modelnya (Minggu 1)

1. Di halaman model, klik tombol **Download 3D Model**.
2. Pilih format **`.fbx`** — format paling aman untuk Unity (langsung bisa di-import). Jangan pilih `.glb`/`.gltf`, karena Unity tidak bisa import format itu tanpa package tambahan.
3. File yang ter-download biasanya berupa **.zip** — ekstrak (klik kanan → Extract) sampai dapat file **.fbx** dan folder **textures**. Simpan keduanya di satu folder yang sama, jangan dipisah.

#### Langkah 30 — Import model ke Unity (Minggu 2)

1. 🔄 **Tunggu Alifa:** project Unity harus sudah dibuat dan di-push (Langkah 8–12). Pull repo terbaru di GitHub Desktop, buka project di Unity Hub.
2. Di jendela **Project**, klik kanan di **Assets** → Create → Folder → **`Models`** → di dalamnya buat folder **`Kafe`**.
3. **Drag file .fbx dan folder textures** dari File Explorer ke folder `Assets/Models/Kafe`. Tunggu import selesai.
4. Klik file **.fbx** → jendela **Inspector** → tab **Model** → cek **Scale Factor**: kalau angkanya 1, biasanya sudah benar (1 unit Unity = 1 meter). Kalau kafenya kelihatan raksasa/kecil sekali di preview, ubah Scale Factor (misalnya jadi 0.01 atau 100) sampai ukurannya masuk akal, lalu klik **Apply**.
5. Masih di Inspector file .fbx → tab **Materials** → klik **Extract Materials** (supaya materialnya bisa diedit), simpan di folder yang sama.
6. **Kalau kafenya jadi warna pink** (pink = material hilang/rusak): pilih semua material hasil extract → di Inspector, ubah **Shader** menjadi **Universal Render Pipeline → Lit**. Pink-nya hilang dan teksturnya muncul lagi.
7. Cek jumlah triangles: klik file .fbx → di bagian bawah Inspector (preview) ada info jumlah triangles — usahakan di bawah 50 ribu. Kalau di atas 100 ribu, cari model lain yang lebih ringan.
8. ✅ Cek hasil: model kafe muncul normal (tidak pink, ukuran masuk akal) saat di-drag ke Scene.

#### Langkah 31 — Cek bagian-bagian model (Minggu 2, PENTING)

1. Drag model .fbx ke Scene (sementara saja, untuk dicek).
2. Di **Hierarchy**, klik segitiga kecil di samping nama kafe untuk membuka isinya.
3. **Bagus (lanjut):** isinya ada bagian terpisah, misalnya `Wall`, `Counter`, `Table`, `Chair`, `Door`. Artinya tiap bagian bisa diganti warna atau dipindah sendiri — fitur kustomisasi Alifa (Langkah 21–22) bisa jalan.
4. **Kurang bagus (jangan dipakai):** isinya cuma satu mesh utuh (misalnya hanya `Cafe` saja, tidak bisa dibuka). Artinya dinding dan perabot menyatu — tidak bisa ganti warna satu dinding saja. Kalau ini yang terjadi: (a) cari model lain yang bagiannya terpisah, atau (b) kustomisasi dibatasi ke bagian yang terpisah saja.
5. Hapus model dari Scene setelah dicek (klik kanan → Delete). Model aslinya tetap aman di folder Project.
6. ✅ Cek hasil: kamu bisa menyebutkan nama child object dinding, counter, dan meja — nama-nama ini yang kamu serahkan ke Alifa (Langkah 33).

#### Langkah 32 — Buat prefab Kafe_Mini dan Kafe_Full (Minggu 2)

1. Drag model .fbx dari Project ke Hierarchy (scene apa saja, sementara).
2. Pilih GameObject kafe itu → di Inspector, atur **Scale**:
   - Untuk miniatur AR: Scale **0,06, 0,06, 0,06** (kafe 6 meter → miniatur 36 cm. Rumus: 0,4 ÷ lebar kafe).
   - Untuk VR: Scale **1, 1, 1** (ukuran asli).
3. Buat prefab miniatur: drag GameObject kafe (yang Scale-nya 0,06) dari Hierarchy ke folder `Assets/Models/Kafe` → beri nama **`Kafe_Mini`**.
4. Ubah Scale GameObject itu jadi (1, 1, 1) → drag lagi ke folder yang sama → beri nama **`Kafe_Full`**.
5. Hapus GameObject kafe dari Hierarchy (prefab-nya sudah tersimpan di Project).
6. ✅ Cek hasil: di folder `Assets/Models/Kafe` ada dua prefab: `Kafe_Mini` dan `Kafe_Full`. Klik `Kafe_Mini` → di preview ukurannya kecil; klik `Kafe_Full` → ukurannya besar.

#### Langkah 33 — Serah terima ke Alifa 🔄 (Akhir Minggu 2)

1. Commit + push semua kerjaanmu: pesan `[Fauzhira] Import model kafe + prefab Kafe_Mini & Kafe_Full`.
2. Kabari Alifa (chat grup) dengan 3 info ini:
   - Nama prefab: `Kafe_Mini` dan `Kafe_Full`, lokasinya `Assets/Models/Kafe`.
   - Nama child object di dalam model: dinding = `...`, counter = `...`, meja = `...` (isi dengan nama sebenarnya dari Langkah 31).
   - Lebar kafe sebenarnya (meter) dan Scale Factor yang kamu pakai.
3. Alifa memakai info ini untuk Langkah 17 (pasang replika di VR) dan Langkah 21–22 (sambung script warna & pindah).

### 2B. AR Specialist — Scene AR, Langkah 34–38

#### Langkah 34 — Buat scene ARScene (Minggu 2–3)

1. Buat scene baru: **File → New Scene** → simpan dengan **File → Save As** → folder `Assets/Scenes` → nama **`ARScene`**.
2. Hapus **Main Camera** bawaan (klik kanan → Delete).
3. Pasang AR Session: klik menu **GameObject → XR → AR Session**.
4. Pasang AR Session Origin: klik menu **GameObject → XR → AR Session Origin**. (Di dalamnya sudah ada AR Camera — itu kamera HP untuk AR.)
5. Pilih GameObject **AR Session Origin** → di Inspector klik **Add Component** → ketik **AR Plane Manager** → pilih. Masih di GameObject yang sama → **Add Component** → ketik **AR Raycast Manager** → pilih.
6. Pilih komponen **AR Plane Manager** → **Plane Detection Mode** → pilih **Horizontal**. (Horizontal artinya hanya mendeteksi permukaan datar seperti meja dan lantai, bukan dinding.)
7. Simpan scene (Ctrl+S).
8. ✅ Cek hasil: di Hierarchy ada AR Session, AR Session Origin (dengan AR Camera, AR Plane Manager, AR Raycast Manager).

#### Langkah 35 — Buat script ARPlaceManager (tap untuk meletakkan miniatur) (Minggu 3)

1. Di folder **Scripts**, buat C# Script baru → beri nama **`ARPlaceManager`**. Isi kodenya:

```csharp
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlaceManager : MonoBehaviour
{
    public GameObject prefabKafeMini;  // drag prefab Kafe_Mini ke sini
    public GameObject reticle;         // lingkaran penanda, drag ke sini
    public ARRaycastManager raycastManager;
    private GameObject kafeYangDiletakkan;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        // 1. Gerakkan reticle mengikuti tengah layar
        Vector3 tengahLayar = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        if (raycastManager.Raycast(tengahLayar, hits, TrackableType.PlaneWithinPolygon))
        {
            reticle.SetActive(true);
            reticle.transform.position = hits[0].pose.position;
        }
        else
        {
            reticle.SetActive(false);
        }

        // 2. Kalau layar disentuh, letakkan / pindahkan kafe
        if (Input.touchCount == 0) return;
        Touch sentuhan = Input.GetTouch(0);
        if (sentuhan.phase != TouchPhase.Began) return;
        if (raycastManager.Raycast(sentuhan.position, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose pose = hits[0].pose;
            if (kafeYangDiletakkan == null)
                kafeYangDiletakkan = Instantiate(prefabKafeMini, pose.position, pose.rotation);
            else
                kafeYangDiletakkan.transform.position = pose.position;
        }
    }

    // 3. Tombol-tombol UI AR
    public void PutarKafe()
    {
        if (kafeYangDiletakkan != null)
            kafeYangDiletakkan.transform.Rotate(0, 45f, 0);
    }

    public void PerbesarKafe()
    {
        if (kafeYangDiletakkan != null)
            kafeYangDiletakkan.transform.localScale *= 1.1f;
    }

    public void PerkecilKafe()
    {
        if (kafeYangDiletakkan != null)
            kafeYangDiletakkan.transform.localScale *= 0.9f;
    }

    public void ResetKafe()
    {
        if (kafeYangDiletakkan != null)
        {
            Destroy(kafeYangDiletakkan);
            kafeYangDiletakkan = null;
        }
    }
}
```

2. Simpan (Ctrl+S), kembali ke Unity, cek Console tidak ada error merah.
3. **Arti kode ini (untuk dijelaskan ke dosen):** `ARRaycast` menembakkan garis tak terlihat dari layar ke dunia nyata untuk mencari plane (lantai/meja) yang terdeteksi ARCore. Kalau ketemu, miniatur diletakkan di titik itu. Reticle adalah lingkaran penanda yang mengikuti tengah layar supaya pengguna tahu di mana miniatur akan muncul sebelum tap.

#### Langkah 36 — Pasang reticle dan sambung script (Minggu 3)

1. Buat reticle (lingkaran penanda): Hierarchy → klik kanan → **3D Object → Cylinder** → beri nama **`Reticle`** → Scale (0.1, 0.01, 0.1) → warna hijau: di Inspector, buat Material baru (klik kanan di Project → Create → Material → warna hijau, transparan) lalu drag ke Reticle.
2. **Matikan (uncheck)** Reticle di Inspector — script yang akan menyalakannya kalau plane terdeteksi.
3. Buat GameObject kosong **`ARManager`** → Add Component → **ARPlaceManager**.
4. Di Inspector `ARManager`, isi kolomnya: drag prefab **`Kafe_Mini`** ke `prefabKafeMini`; drag GameObject **`Reticle`** ke `reticle`; drag GameObject **AR Session Origin** ke `raycastManager`.
5. Sambung tombol UI AR (Fadhilah yang membuat tombolnya — lihat Bagian 3): tombol **"Putar"** → On Click → `ARManager` → **ARPlaceManager → PutarKafe()**; **"Perbesar"** → **PerbesarKafe()**; **"Perkecil"** → **PerkecilKafe()**; **"Reset"** → **ResetKafe()**; tombol **"Masuk VR"** → GameManager → PindahKeVR() (Langkah 15, Alifa).
6. Simpan scene (Ctrl+S).
7. ✅ Cek hasil: tekan Play di editor (mode simulasi AR tidak jalan penuh di editor — cek di HP di Langkah 37).

#### Langkah 37 — Uji AR di HP Galaxy A23 (Minggu 3)

1. Minta Alifa build APK (Langkah 25) atau build sendiri dengan cara yang sama.
2. Instal APK di A23, buka aplikasi, izinkan **kamera** saat diminta.
3. Arahkan kamera ke meja/lantai yang terang dan bertekstur (meja kayu / lantai keramik paling gampang terdeteksi; meja kaca atau lantai polos mengkilap susah).
4. Cek satu per satu:
   - [ ] Titik-titik plane muncul di layar (bintik-bintik deteksi lantai).
   - [ ] Reticle hijau muncul dan mengikuti tengah layar.
   - [ ] Tap layar → miniatur kafe muncul di titik tap.
   - [ ] Tap titik lain → miniatur pindah ke sana.
   - [ ] Tombol Putar / Perbesar / Perkecil / Reset berfungsi.
   - [ ] Gerakkan HP mengelilingi meja → miniatur tetap menempel, tidak goyang/geser.
   - [ ] Tombol "Masuk VR" → pindah ke VRScene.
5. **Catat hasilnya:** kecepatan deteksi plane (berapa detik sampai plane muncul), kestabilan tracking (goyang/tidak), dan FPS (kalau bisa diukur — target ≥ 30 FPS). Kirim catatan ini ke Fadhilah untuk laporan.
6. **Kalau plane tidak terdeteksi:** pindah ke permukaan yang lebih terang dan bertekstur, gerakkan HP perlahan naik-turun, atau bersihkan lensa kamera. Kalau tetap tidak bisa, catat sebagai masalah (masuk laporan bagian Masalah & Solusi) dan pakai video demo sebagai cadangan.

#### Langkah 38 — Polish AR (Minggu 4)

1. Perbaiki hal-hal kecil dari hasil uji: posisi reticle, ukuran tombol, pesan kalau plane belum terdeteksi (misalnya teks "Arahkan kamera ke meja/lantai...").
2. Pastikan miniatur tidak menembus meja (Position Y miniatur = posisi plane, jangan diubah).
3. Commit + push: `[Fauzhira] Scene AR lengkap + hasil uji A23`.

### 2C. Presenter/Demo — Bagian AR (Minggu 6)

#### Langkah 39 — Siapkan penjelasan AR (untuk presentasi)

1. Hafalkan 3 poin ini (pakai bahasamu sendiri, jangan dihafal kata per kata):
   - **Apa itu Ground Plane:** HP mendeteksi permukaan datar (meja/lantai) lewat kamera + sensor, lalu kita meletakkan model 3D di atasnya. Tidak pakai marker cetak sama sekali.
   - **Kenapa AR Foundation + ARCore:** gratis, standar industri, plane detection sudah bawaan, dan jalan di HP Android biasa (tidak butuh headset).
   - **Cara kerja tap-to-place:** sentuhan di layar diubah jadi garis (raycast) ke plane yang terdeteksi, lalu miniatur muncul di titik itu. Reticle menunjukkan dulu titiknya sebelum tap.
2. Siapkan jawaban untuk pertanyaan dosen yang paling mungkin:
   - "Kenapa tidak pakai Vuforia?" → Vuforia juga diizinkan PPTX, tapi ARCore lebih pas untuk ground plane dan gratis, dan kami sudah pakai AR Foundation yang memang dibuat untuk ini.
   - "Kenapa tidak pakai marker?" → Ground Plane memang tidak butuh marker — itu kelebihannya dibanding project silinder kemarin yang butuh wrapper cetak.
   - "Kenapa miniaturnya kadang goyang?" → Tracking ARCore bergantung cahaya dan tekstur permukaan; di permukaan terang bertekstur hasilnya stabil (ini hasil uji kami).

---

## Bagian 3 — FADHILAH (UI/UX Designer + QA/Tester + Documentation)

### 3A. UI/UX Designer — Menu & panel, Langkah 40–44

#### Langkah 40 — Atur Canvas dulu (Minggu 1–2, sekali untuk semua UI)

1. Di scene **ARScene**, klik kanan di Hierarchy → **UI → Canvas**.
2. Pilih **Canvas** → di Inspector, cari **Canvas Scaler** → **UI Scale Mode** → pilih **Scale With Screen Size** → **Reference Resolution** → isi **1080 × 1920** (ukuran layar HP portrait).
3. **Aturan ukuran tombol:** semua tombol minimal **120 × 120 piksel** di Canvas ini, supaya gampang ditekan jari di HP. Teks tombol minimal **28 pt**.
4. **Aturan warna:** teks harus kontras dengan latarnya (teks putih di atas tombol gelap, atau teks hitam di atas tombol terang). Jangan pakai teks abu-abu muda di atas latar putih — tidak terbaca di HP di bawah matahari.
5. Ulangi langkah 1–2 di scene **VRScene** (Canvas terpisah per scene).

#### Langkah 41 — Buat menu awal (Minggu 2)

1. Di **ARScene** (scene pertama yang dibuka aplikasi), di dalam Canvas, buat panel menu: klik kanan Canvas → **UI → Panel** → beri nama **`MenuAwal`**.
2. Di dalam `MenuAwal`, buat:
   - **Judul:** klik kanan MenuAwal → UI → Text - TextMeshPro → tulis **"Coffee Shop AR + VR"** (kalau muncul pop-up "Import TMP Essentials", klik Import).
   - **Tombol "Mulai AR":** klik kanan MenuAwal → UI → Button - TextMeshPro → beri nama `BtnMulaiAR` → ubah teksnya jadi "Mulai AR".
   - **Tombol "Langsung ke VR":** sama seperti di atas → `BtnLangsungVR` → teks "Langsung ke VR".
   - **Tombol "Cara Pakai":** → `BtnCaraPakai` → teks "Cara Pakai".
   - **Tombol "Tentang":** → `BtnTentang` → teks "Tentang".
3. Buat panel instruksi (tersembunyi dulu): klik kanan Canvas → UI → Panel → **`PanelCaraPakai`** → isi teks: "1. Arahkan kamera ke meja/lantai. 2. Tap layar untuk meletakkan miniatur kafe. 3. Tekan 'Masuk VR' untuk masuk ke dalam kafe. 4. Di VR, pakai tombol di layar untuk pindah dan ganti warna." → tambah tombol **"Tutup"** → **matikan (uncheck)** PanelCaraPakai.
4. Buat panel Tentang (tersembunyi dulu): **`PanelTentang`** → isi teks: nama kelompok, anggota, peran, dan "Model 3D kafe dari Sketchfab (lisensi ...)" → tombol **"Tutup"** → **matikan**.
5. Sambung tombol (On Click):
   - `BtnMulaiAR` → **GameManager → PindahKeAR()**? Tidak — aplikasi sudah dibuka di ARScene. Yang benar: tombol ini **menutup MenuAwal** (drag MenuAwal → GameObject → SetActive, centang **tidak** dicentang = false). Cara paling gampang: buat method kecil? Tidak perlu script — di On Click tombol, pilih **GameObject → SetActive(bool)** dan biarkan kotaknya **tidak tercentang** (false) untuk MenuAwal. Ulangi: drag MenuAwal ke On Click → pilih **GameObject → SetActive** → pastikan kotaknya kosong (false).
   - `BtnLangsungVR` → drag **GameManager** → **GameManager → PindahKeVR()**.
   - `BtnCaraPakai` → drag **PanelCaraPakai** → **GameObject → SetActive** → kotaknya **tercentang** (true).
   - Tombol "Tutup" di PanelCaraPakai → drag **PanelCaraPakai** → **SetActive** → kotak **kosong** (false). Sama untuk PanelTentang.
6. ✅ Cek hasil: tekan Play → menu muncul → klik "Cara Pakai" → panel instruksi muncul → klik "Tutup" → panel hilang. Klik "Mulai AR" → menu hilang, kamera AR menyala.

#### Langkah 42 — Buat tombol UI AR (Minggu 2–3)

1. Di **ARScene**, di dalam Canvas (di luar MenuAwal), buat tombol-tombol ini (klik kanan Canvas → UI → Button - TextMeshPro, atur posisi di bawah layar supaya tidak menutupi kamera):
   - **`BtnPutar`** (teks "Putar"), **`BtnPerbesar`** ("Perbesar"), **`BtnPerkecil`** ("Perkecil"), **`BtnResetAR`** ("Reset"), **`BtnMasukVR`** ("Masuk VR" — buat lebih besar dan warna beda, karena ini tombol utama).
2. Sambung On Click-nya (lihat Langkah 36 untuk nama method-nya):
   - `BtnPutar` → drag **ARManager** → **ARPlaceManager → PutarKafe()**.
   - `BtnPerbesar` → **PerbesarKafe()**. `BtnPerkecil` → **PerkecilKafe()**. `BtnResetAR` → **ResetKafe()**.
   - `BtnMasukVR` → drag **GameManager** → **PindahKeVR()**.
3. ✅ Cek hasil: tekan Play → semua tombol muncul di bawah layar dan bisa diklik.

#### Langkah 43 — Buat panel info & panel kustomisasi VR (Minggu 3)

1. Di **VRScene**, di dalam Canvas, buat panel info: klik kanan Canvas → UI → Panel → **`PanelInfo`** → di dalamnya: Text judul (misalnya "Counter") + Text deskripsi ("Tempat memesan kopi...") + tombol **"Tutup"** → **matikan (uncheck)** PanelInfo dulu.
2. Buat panel kustomisasi: klik kanan Canvas → UI → Panel → **`PanelKustomisasi`** → di dalamnya:
   - **Baris "Pilih bagian":** tombol **"Dinding"**, **"Counter"**, **"Meja"**.
   - **Baris "Pilih warna":** tombol **"Krem"**, **"Cokelat Muda"**, **"Hijau Sage"**, **"Cokelat Tua"**, **"Hitam"**, **"Putih"**.
   - **Baris "Susunan meja":** tombol **"3 Meja Pisah"**, **"1 Meja Besar"**, **"Sisi Jendela"**.
   - **Tombol "Reset"** (kembalikan warna + susunan awal).
3. Sambung On Click-nya:
   - "Dinding" → drag **PengaturWarna** → **GantiWarna → PilihDinding()**. "Counter" → **PilihCounter()**. "Meja" → **PilihMeja()**.
   - Tombol warna (misalnya "Krem") → **GantiWarna → GantiKeWarna()** → klik kotak warna di Inspector lalu pilih warna krem. Ulangi tiap tombol warna dengan warnanya masing-masing.
   - "3 Meja Pisah" → drag **PengaturSusunan** → **SusunanMeja → SusunanPisah()**. "1 Meja Besar" → **SusunanBesar()**. "Sisi Jendela" → **SusunanJendela()**.
   - "Reset" → drag **PengaturWarna** → **ResetWarna()** (klik + sekali lagi) → drag **PengaturSusunan** → **SusunanPisah()**. (Satu tombol boleh punya dua On Click.)
4. Buat tombol teleport: **`BtnKePintu`** ("Ke Pintu"), **`BtnKeCounter`** ("Ke Counter"), **`BtnKeMeja`** ("Ke Meja") → sambung ke script TeleportTombol (Langkah 19).
5. Buat tombol **"Kembali ke AR"** → drag **GameManager** → **PindahKeAR()**.
6. ✅ Cek hasil: tekan Play di VRScene → panel kustomisasi muncul → klik "Dinding" lalu "Krem" → dinding berubah krem. Klik "1 Meja Besar" → meja berkumpul di tengah. Klik "Reset" → kembali seperti awal.

#### Langkah 44 — Audio (Minggu 3–4, opsional tapi bagus)

1. Suara klik tombol: download gratis di **freesound.org** (cari "button click", pilih yang lisensinya CC0) → simpan file .mp3/.wav ke `Assets/Audio` → catat nama pembuat + lisensi untuk laporan.
2. Di Unity, pilih tombol → di Inspector, tambahkan **Audio Source**? Cara paling gampang: buat GameObject kosong **`AudioManager`** → Add Component → **Audio Source** → drag file suara ke **Audio Clip** → di tiap tombol, On Click (+) → drag `AudioManager` → **AudioSource → Play()**.
3. Musik latar (opsional): cari musik bebas lisensi (misalnya di YouTube Audio Library) → catat sumbernya → pasang Audio Source dengan **Loop** tercentang di VRScene.
4. ✅ Cek hasil: klik tombol → ada suara klik. Kalau tidak ada suara, cek volume HP dan Audio Source tidak dalam keadaan Mute.

### 3B. QA/Tester — Uji usability + SSQ, Langkah 45–48

#### Langkah 45 — Siapkan lembar uji usability (Minggu 4)

1. Buat lembar observasi (di kertas atau Google Docs) dengan 6 tugas ini. Penguji adalah **5–10 orang di luar anggota kelompok** (teman kelas lain, misalnya).
2. Tugas yang diberikan ke penguji (jangan dibantu, hanya diamati):
   1. Buka aplikasi, letakkan miniatur kafe di meja.
   2. Buka info satu bagian (misalnya counter).
   3. Tekan "Masuk VR".
   4. Teleport ke 2 titik (misalnya ke counter, lalu ke meja).
   5. Ganti warna dinding.
   6. Kembali ke AR.
3. Untuk tiap tugas, catat: **berhasil tanpa bantuan? (ya/tidak)**, **di mana dia bingung?**, **berapa lama?** (pakai stopwatch HP).
4. Setelah selesai, tanya 3 pertanyaan: "Bagian mana yang paling membingungkan?", "Tombol mana yang susah ditekan?", "Apa yang kamu harapkan ada tapi tidak ada?"
5. ✅ Cek hasil: kamu punya catatan untuk 5–10 orang, lengkap dengan bagian yang membingungkan.

#### Langkah 46 — SSQ, kuesioner mabuk VR (Minggu 5)

1. **Apa itu SSQ:** Simulator Sickness Questionnaire — kuesioner standar 16 gejala untuk mengukur rasa tidak nyaman setelah memakai VR. PPTX mewajibkan hasilnya ada di laporan.
2. **16 gejalanya (tulis di Google Form / kertas):** (1) Rasa tidak nyaman secara umum, (2) Kelelahan, (3) Sakit kepala, (4) Mata tegang, (5) Sulit fokus, (6) Air liur bertambah, (7) Berkeringat, (8) Mual, (9) Sulit berkonsentrasi, (10) Kepala terasa penuh, (11) Penglihatan kabur, (12) Pusing dengan mata terbuka, (13) Pusing dengan mata tertutup, (14) Ruangan berputar, (15) Perut tidak nyaman, (16) Sendawa.
3. **Cara isi:** tiap gejala diberi skor **0 = tidak ada, 1 = ringan, 2 = sedang, 3 = berat**. Penguji mengisi **SEBELUM** memakai VR dan **SESUDAH** memakai VR (5 menit di VR).
4. **Cara hitung skor (rumus standar Kennedy, 1993):**
   - Mual (Nausea) = (gejala 1+6+7+8+9+15+16) × 9,54
   - Mata (Oculomotor) = (gejala 2+3+4+5+9+10+11) × 7,58
   - Pusing (Disorientation) = (gejala 5+8+10+11+12+13+14) × 13,92
   - **Total = (jumlah mentah ketiga kelompok di atas) × 3,74**
   - Contoh: kalau jumlah mentah ketiga kelompok = 10, maka Total SSQ = 10 × 3,74 = **37,4**. Makin besar angkanya, makin banyak yang merasa tidak nyaman.
5. Hitung rata-rata Total SSQ sebelum dan sesudah untuk semua penguji. Tulis di laporan: "Rata-rata SSQ sebelum VR = ..., sesudah VR = ... — artinya ...". (Kalau sesudah jauh lebih besar dari sebelum, tulis jujur di laporan + apa yang dilakukan untuk mengurangi, misalnya teleport, bukan jalan terus-menerus.)
6. ✅ Cek hasil: kamu punya skor SSQ sebelum & sesudah dari minimal 5 orang.

#### Langkah 47 — Bug log (Minggu 5, selama pengujian)

1. Buat tabel bug (Google Sheets / kertas) dengan kolom: **Tanggal | Siapa menemukan | Langkah memunculkan bug | Yang terjadi | Yang seharusnya | Status (baru/diperbaiki)**.
2. Setiap bug yang ditemukan saat uji (oleh siapa pun) langsung ditulis di tabel ini — jangan cuma diceritakan lewat chat, nanti hilang.
3. Kirim tabel bug ke Alifa + Fauzhira tiap selesai satu sesi uji. Mereka memperbaiki, build ulang, lalu kamu uji ulang bug yang sama.
4. ✅ Cek hasil: semua bug di tabel berstatus "diperbaiki" sebelum Minggu 6, atau ditulis alasannya kalau tidak sempat diperbaiki (masuk laporan bagian Masalah & Solusi).

#### Langkah 48 — Uji ulang setelah perbaikan (Minggu 5)

1. Setelah bug diperbaiki dan APK baru dibuild, uji ulang dengan **minimal 3 orang** (boleh orang yang sama dengan uji pertama).
2. Fokus ke bug yang tadi ditemukan: apakah sudah hilang? Apakah muncul bug baru?
3. ✅ Cek hasil: masalah utama dari uji pertama sudah hilang. Kalau masih ada, ulangi Langkah 47 sekali lagi.

### 3C. Documentation — Laporan, slide, video, Langkah 49–52

#### Langkah 49 — Laporan PDF 6–12 halaman (Minggu 6)

1. Ikuti struktur PPTX slide 23, urutannya: **Judul** (nama kelompok, anggota, peran) → **Abstrak** (maks 200 kata) → **Tujuan & Scope** → **Metode & Tools** (Unity 2022.3 LTS, AR Foundation + ARCore, OpenXR + XR Interaction Toolkit, HP A23) → **Arsitektur Sistem & Flow AR→VR (diagram)** → **Implementasi** (cuplikan kode + penjelasan singkat) → **Pengujian & Hasil** (usability + SSQ + performa/FPS) → **Masalah & Solusi** (dari bug log) → **Kesimpulan & Pengembangan Lanjutan** → **Referensi & Lisensi Aset** (model kafe Sketchfab + suara + musik) → **Lampiran** (link repo, build, video).
2. **Diagram Flow AR→VR:** buat di draw.io (gratis, draw.io) atau Canva — kotak-kotak: `Buka Aplikasi` → `ARScene: deteksi plane → tap → miniatur kafe` → `Tombol "Masuk VR"` → `VRScene: jalan keliling → teleport → ganti warna → pindah meja` → `Tombol "Kembali ke AR"`. Simpan sebagai gambar, masukkan ke laporan.
3. Minta tiap orang menulis bagian yang dia kerjakan (Alifa: arsitektur + VR + build; Fauzhira: AR + model; kamu: UI + pengujian + SSQ). Kamu yang merapikan jadi satu dokumen.
4. ✅ Cek hasil: laporan 6–12 halaman, semua bagian ada, link repo + video + APK bisa dibuka.

#### Langkah 50 — Slide presentasi maks 10 menit (Minggu 6)

1. Outline slide (8–10 slide): (1) Judul + anggota, (2) Masalah (pemilik kafe susah membayangkan hasil renovasi), (3) Metode (Ground Plane AR + Room-Scale VR), (4) Arsitektur & Flow AR→VR (diagram), (5) Demo AR (screenshot), (6) Demo VR (screenshot + fitur kustomisasi), (7) Hasil uji (usability + SSQ + FPS), (8) Masalah & solusi, (9) Kesimpulan, (10) Terima kasih + link repo.
2. Latihan presentasi dengan timer — total **maks 10 menit**. Bagi waktu bicara: Alifa ±3 menit (arsitektur & tools), Fauzhira ±3 menit (demo AR), kamu ±3 menit (demo VR + hasil uji), sisa 1 menit untuk penutup.
3. ✅ Cek hasil: latihan 2 kali, waktunya tidak lebih dari 10 menit.

#### Langkah 51 — Video demo maks 7 menit, min 720p (Minggu 6, bareng bertiga)

1. Rekam layar HP A23 dengan **Screen Recorder bawaan Samsung** (geser layar dari atas ke bawah → cari ikon Screen Recorder). Atur kualitas minimal 720p.
2. Urutan rekaman (total maks 7 menit):
   - **0:00–0:30** — Intro: perkenalan kelompok + setup perangkat (HP A23).
   - **0:30–2:00** — Demo AR: arahkan kamera ke meja → plane terdeteksi → tap → miniatur kafe muncul → putar/perbesar miniatur.
   - **2:00–2:30** — Transisi: tekan tombol "Masuk VR".
   - **2:30–5:00** — Demo VR: jalan keliling kafe → teleport ke 3 titik → ganti warna dinding → pindah meja → coba susunan meja → Reset.
   - **5:00–6:00** — Error handling: contoh plane tidak terdeteksi → apa yang dilakukan (pindah ke meja yang lebih terang).
   - **6:00–7:00** — Penutup: kesimpulan + link repo di deskripsi.
3. Edit video (CapCut gratis, di HP atau laptop) → tambah teks judul tiap bagian → export 720p atau lebih.
4. Upload ke **Google Drive** → atur **Anyone with the link can view** → salin linknya → masukkan ke laporan dan README.
5. ✅ Cek hasil: video ≤ 7 menit, ≥ 720p, link Drive bisa dibuka dari HP lain.

#### Langkah 52 — Update README repo (Minggu 6)

1. Buka file **README** di repo → isi tabel **Lisensi aset luar** dengan data dari Fauzhira (Langkah 28) dan audio (Langkah 44): nama aset, sumber, lisensi.
2. Pastikan README menjelaskan cara build/run langkah demi langkah (salin dari file README project yang sudah dibuat).
3. ✅ Cek hasil: orang luar yang membaca README bisa build dan menjalankan aplikasi tanpa bertanya ke kelompok.

### 3D. Presenter/Demo — Bagian VR (Minggu 6)

#### Langkah 53 — Siapkan penjelasan VR (untuk presentasi)

1. Hafalkan 3 poin ini (pakai bahasamu sendiri):
   - **Cara kerja VR di HP ("jendela ajaib"):** tidak ada headset, jadi kamera mengikuti sensor giroskop HP — gerakkan HP untuk melihat sekeliling, teleport dan interaksi lewat tombol di layar.
   - **Kenapa OpenXR + XR Interaction Toolkit:** standar Unity, gratis, dan kalau suatu saat dicoba di Quest, aplikasinya langsung jalan tanpa ubah kode.
   - **Jujur soal keterbatasan:** mode HP hanya 3DoF (putar kepala saja, jalan fisik tidak terbaca) — bukan room-scale penuh 6DoF. Itu sebabnya geraknya pakai teleport, bukan jalan beneran. Ini harus disebutkan di presentasi dan laporan, bukan disembunyikan.
2. Siapkan jawaban untuk pertanyaan dosen yang paling mungkin:
   - "Kenapa tidak jalan beneran di VR?" → Karena demo di HP tanpa headset — jalan fisik tidak terbaca. Teleport adalah penggantinya, dan ini ditulis jujur di laporan. Kalau ada Quest, tinggal jalankan aplikasi yang sama.
   - "Apa yang paling susah di VR?" → Membuat interaksi (ganti warna, pindah meja) tetap bisa dipakai lewat tombol layar, karena di HP tidak ada controller seperti di Quest.

---

## Bagian 4 — Kerja bareng (semua orang)

### Langkah 54 — Daftar serah terima (🔄) — jangan dilewati

| # | Dari → Ke | Yang diserahkan | Kapan |
|---|---|---|---|
| 1 | Alifa → Fauzhira & Fadhilah | Repo GitHub + link clone | Minggu 1 |
| 2 | Fauzhira → Alifa | Prefab `Kafe_Mini` & `Kafe_Full` + nama bagian (dinding/counter/meja) + lebar kafe | Akhir Minggu 2 |
| 3 | Fadhilah → Alifa & Fauzhira | Nama tombol & panel UI (supaya On Click disambung ke script yang benar) | Minggu 2–3 |
| 4 | Alifa → Fadhilah | APK untuk diuji | Minggu 5 |
| 5 | Fadhilah → Alifa & Fauzhira | Tabel bug + hasil usability + skor SSQ | Minggu 5 |
| 6 | Semua → Semua | Video demo + slide + laporan (dikerjakan bareng) | Minggu 6 |

### Langkah 55 — Gladi demo (Minggu 6)

1. Jalankan demo lengkap dari awal sampai akhir di HP yang sama dengan yang dipakai saat presentasi (**Galaxy A23**). Jangan ganti HP di hari-H.
2. Bagi peran saat demo: **Fauzhira** memegang HP untuk bagian AR, **Fadhilah** memegang HP untuk bagian VR, **Alifa** menjelaskan sambil menunjuk layar (atau sebaliknya — sesuaikan dengan yang paling nyaman).
3. **Rencana cadangan (siapkan sebelum hari-H):**
   - Kalau plane tidak terdeteksi saat demo → jangan panik di depan dosen, putar **video demo** sebagai pengganti dan jelaskan sambil videonya jalan.
   - Kalau HP bermasalah → pakai **mode walkthrough PC** di laptop (Langkah 23).
   - Kalau aplikasi crash → buka lagi dari awal; pastikan APK versi terbaru sudah terinstal sebelum presentasi.
4. ✅ Cek hasil: gladi 2 kali tanpa masalah besar.

### Langkah 56 — Checklist akhir (sebelum dikumpulkan)

- [ ] APK terinstal & berjalan di HP (AR + VR)
- [ ] Transisi AR → VR dan VR → AR berfungsi
- [ ] Repo GitHub lengkap (`/src`, `/assets`, `/build`, `/docs`, `/demo` + README)
- [ ] Video demo ≤ 7 menit, ≥ 720p, link Drive aktif
- [ ] Laporan PDF 6–12 halaman sesuai struktur slide 23 (termasuk SSQ + performa)
- [ ] Slide presentasi ≤ 10 menit
- [ ] Lisensi semua aset luar dicantumkan (model kafe, suara, musik)
- [ ] Hasil uji usability + SSQ + performa ada di laporan
- [ ] Tidak ada kode/hasil copy-paste tanpa atribusi

### Langkah 57 — Kalau macet (troubleshooting umum)

| Masalah | Kemungkinan penyebab | Yang dilakukan |
|---|---|---|
| Build APK gagal | Package belum ter-install / Player Settings salah | Cek Langkah 10 (package) dan Langkah 12 (IL2CPP, ARM64, OpenGLES3, Min API 26) |
| Aplikasi crash saat dibuka | Scene pertama bukan ARScene / ARCore tidak support di HP | Cek Build Settings: ARScene index 0; pastikan HP-nya A23, bukan A15 |
| Kamera AR hitam | Izin kamera belum diberikan | Hapus data aplikasi di HP → buka lagi → izinkan kamera saat diminta |
| Plane tidak terdeteksi | Permukaan gelap / polos / mengkilap | Pindah ke meja/lantai yang terang dan bertekstur; gerakkan HP perlahan |
| Miniatur goyang/geser | Cahaya kurang / permukaan kurang tekstur | Sama seperti di atas; catat di laporan |
| Model kafe warna pink | Shader tidak cocok | Ubah Shader material ke URP → Lit (Langkah 30) |
| Tombol tidak berfungsi | On Click belum disambung / salah target | Cek Inspector tombol → On Click → target dan method-nya benar |
| VR hitam di HP | XR Origin mati / kamera ganda | Pastikan hanya satu kamera aktif (XR Origin nyala, PCPlayer mati — Langkah 23) |
| Pandangan VR terbalik | Rumus giroskop terbalik | Balik tanda minus di `KameraGiroskop` (Langkah 20), build ulang |

---

## Penutup

Total **57 langkah** untuk bertiga. Kerjakan sesuai urutan, jangan lompat.
Kalau satu langkah macet lebih dari 1 jam, berhenti dan tanya ke teman atau
catat sebagai masalah — jangan diam-diam mengganti rencana sendiri.

**Yang dibangun sendiri oleh kelompok:** penempatan AR, transisi, interaksi VR
(ganti warna, pindah meja, susunan meja), UI, video, laporan, dan presentasi.
**Yang di-download:** model 3D kafe dari Sketchfab (lisensi CC0/CC BY, atribusi
dicantumkan). Itu pembagian yang jujur dan bisa dipertahankan di depan dosen.

*Dibuat 16 November 2026. Menggabungkan: rencana project (57 langkah, 10 fase),
tutorial download model Sketchfab, denah Coffee Shop 6 × 4 m, dan pembagian
10 peran PPTX ke 3 orang (Alifa: Project Leader + Lead Developer + VR Specialist
+ DevOps/Cloud; Fauzhira: AR Specialist + 3D Artist; Fadhilah: UI/UX Designer +
QA/Tester + Documentation; Presenter/Demo bergiliran).*

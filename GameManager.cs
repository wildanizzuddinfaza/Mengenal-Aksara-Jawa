using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    [Header("Pengaturan Halaman Menu")]
    public string Halaman_Menu;
    public string Halaman_Kuis_Pertama;
    public string Halaman_Hasil;


    [Header("Pengaturan Halaman Permainan")]

    public string jawaban_benar;
    public int bobot;
    public string halamanSelanjutnya;

    public AudioClip suaraBenar;
    public AudioClip suaraSalah;
    public AudioSource suara;
    public GameObject popupBenar;
    public GameObject popupSalah;
    public GameObject popuptransparan;
    int step;
    string text_jawaban;

    [Header("Untuk Keperluan Debugging, Tidak Perlu Diisi !")]
    public int nilai;

    [Header("Pengaturan Halaman Hasil")]
    public GameObject[] bintang;
    public Text text_score;
    public int batas_bintang_1;
    public int batas_bintang_2;
    public int batas_bintang_3;



    // Start is called before the first frame update
    void Start()
    {
        nilai = PlayerPrefs.GetInt("nilai");

        if (SceneManager.GetActiveScene().name == Halaman_Menu)
        {
            PlayerPrefs.SetString("halaman_kuis_Pertama", Halaman_Kuis_Pertama);
            PlayerPrefs.SetString("halaman_hasil", Halaman_Hasil);

        }
        else if (SceneManager.GetActiveScene().name == PlayerPrefs.GetString("halaman_hasil"))
        {
            PemberianBintang();
        }
        else if (SceneManager.GetActiveScene().name == PlayerPrefs.GetString("halaman_kuis_Pertama"))
        {
            PlayerPrefs.SetInt("nilai", 0);
        }


    }

    public void Jawaban_User(string jawaban)
    {
        popuptransparan.SetActive(true);
        if (jawaban == jawaban_benar)
        {
            popupBenar.SetActive(true);
            JawabanBenar();
        }
        else
        {
            popupSalah.SetActive(true);
            JawabanSalah();
        }

       StartCoroutine(NextHalaman());
    }

    public void JawabanBenar()
    {
        suara.clip = suaraBenar;
        suara.Play();

        nilai = PlayerPrefs.GetInt("nilai");
        nilai = nilai + bobot;
        PlayerPrefs.SetInt("nilai",nilai);
    }

    void JawabanSalah()
    {
        suara.clip = suaraSalah;
        suara.Play();
    }

    IEnumerator NextHalaman()
    {
        yield return new WaitForSeconds(1f);
        PindahHalaman(halamanSelanjutnya);
    }

    // CONSTANT

    void PemberianBintang()
    {
        if (nilai <= batas_bintang_1)
        {
            bintang[0].SetActive(true);
            bintang[1].SetActive(false);
            bintang[2].SetActive(false);
        }
        else if (nilai <= batas_bintang_2)
        {
            bintang[0].SetActive(true);
            bintang[1].SetActive(true);
            bintang[2].SetActive(false);
        }
        else if (nilai <= batas_bintang_3)
        {
            bintang[0].SetActive(true);
            bintang[1].SetActive(true);
            bintang[2].SetActive(true);
        }

        text_score.text = "Nilai: " + nilai;
    }

    public void PindahHalaman(string halamanTujuan)
    {
        SceneManager.LoadScene(halamanTujuan);
    }

    public void Open_Popup(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    public void Close_Popup(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    public void Keluar_Aplikasi()
    {
        Application.Quit();
    }


    

}

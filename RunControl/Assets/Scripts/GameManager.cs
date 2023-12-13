using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject DogmaNoktasi;
    public GameObject VarisNoktasi;
    public int AnlikKarakterSayisi = 1;

    public List<GameObject> Karakterler; //sonradan eklenen karakterleri bu havuz içerisinden alıcaz.

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode
                .A)) // A harfine basınca listedeki aktif olmayan objeleri buluyor ve bunları aktifleştirerek doğma noktasında pozisyonluyor
        {
            foreach (var item in Karakterler)
            {
                if (!item.activeInHierarchy) //listede ilk aktif olmayan objeyi bulucak.
                {
                    item.transform.position =
                        DogmaNoktasi.transform.position; //pozisyonunu doğma noktası pozisyonuna eşitleyecek.
                    item.SetActive(
                        true); //objeyi aktifleştirdim. Böylece doğma noktasında bir objeyi aktif etmiş oldum.
                    AnlikKarakterSayisi++;
                    break;
                }
            }
        }
    }

    public void AdamYönetimi(string veri, Transform pozisyon)
    {
        switch (veri)
        {
            case "x2":
                int sayi = 0;
                foreach (var item in Karakterler)
                {
                    if (sayi < AnlikKarakterSayisi)
                    {
                        if (!item.activeInHierarchy) //listede ilk aktif olmayan objeyi bulucak.
                        {
                            item.transform.position =
                                pozisyon.position; //pozisyonunu geçtiği noktadaki objenin pozisyonuna eşitleyecek.
                            item.SetActive(
                                true); //objeyi aktifleştirdim. Böylece doğma noktasında bir objeyi aktif etmiş oldum.
                            sayi++;
                        }
                    }
                    else
                    {
                        sayi = 0;
                        break;
                    }
                }

                AnlikKarakterSayisi *= 2;
                break;
            case "+3":
                int sayi2 = 0;
                foreach (var item in Karakterler)
                {
                    if (sayi2 < 3)
                    {
                        if (!item.activeInHierarchy)
                        {
                            item.transform.position = pozisyon.position;
                            item.SetActive(true);
                            sayi2++;
                        }
                    }
                    else
                    {
                        sayi2 = 0;
                        break;
                    }
                }

                AnlikKarakterSayisi += 3;
                break;
            case "-4":
                if (AnlikKarakterSayisi < 4) // karakter sayısı 4 ün altında ise ana karakter dışındaki tüm karakterleri false yap
                {
                    foreach (var item in Karakterler)
                    {
                        item.transform.position = Vector3.zero;
                        item.SetActive(false);
                    }

                    AnlikKarakterSayisi = 1;
                }
                else
                {
                    int sayi3 = 0;
                    foreach (var item in Karakterler)
                    {
                        if (sayi3 !=4)
                        {
                            if (item.activeInHierarchy)
                            {
                                item.transform.position = Vector3.zero;
                                item.SetActive(false);
                                sayi3++;
                            }
                        }
                        else
                        {
                            sayi3 = 0;
                            break;
                        }
                    }
                }
                AnlikKarakterSayisi -= 4;
                break;
            case "/2":
                if (AnlikKarakterSayisi <= 2) 
                {
                    foreach (var item in Karakterler)
                    {
                        item.transform.position = Vector3.zero;
                        item.SetActive(false);
                    }

                    AnlikKarakterSayisi = 1;
                }
                else
                {
                    int bolen = AnlikKarakterSayisi / 2;
                    int sayi4 = 0;
                    foreach (var item in Karakterler)
                    {
                        if (sayi4 != bolen)
                        {
                            if (item.activeInHierarchy)
                            {
                                item.transform.position = Vector3.zero;
                                item.SetActive(false);
                                sayi4++;
                            }
                        }
                        else
                        {
                            sayi4 = 0;
                            break;
                        }
                    }

                    if (AnlikKarakterSayisi % 2 == 0)
                    {
                        AnlikKarakterSayisi /= 2;
                    }
                    else
                    {
                        AnlikKarakterSayisi /= 2;
                        AnlikKarakterSayisi++;
                    }
                }
                
                break;
        }
    }
}
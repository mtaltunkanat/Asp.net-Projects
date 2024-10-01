using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _11abilişim_mta_proje.Models;
using System.Data.SqlClient;

namespace _11abilişim_mta_proje.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Form()
    {
        return View();
    }

    public IActionResult KisiKayit()
    {
        
        return View();
    }

    public IActionResult FormPost(IFormCollection formgelen, IFormFile Resim)
    {
        if (Resim == null || Resim.Length == 0){
            ViewData["mesaj"]="Resim Yüklenemedi.";
        }
        else{
            var yol=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/resimler",Resim.FileName);
            Resim.CopyTo(new FileStream(yol,FileMode.Create));
            ViewData["mesaj"]="Dosya Yükleme Tamamlandı.";
        }
        
         int sayi1 =int.Parse(formgelen["s1"].ToString());
        int sayi2 =int.Parse(formgelen["s2"].ToString());
        ViewData["carp"]=sayi1*sayi2;
        ViewData["bol"]=sayi1/sayi2;
        ViewData["topla"]=sayi1+sayi2;
        ViewData["fark"]=sayi1-sayi2;

        return View();
    }

    public IActionResult FormPostIslem(IFormCollection formgelen, IFormFile Resim)
    {
        if (Resim == null || Resim.Length == 0){
            ViewData["mesaj"]="Resim Yüklenemedi.";
        }
        else{
            var yol=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/resimler",Resim.FileName);
            Resim.CopyTo(new FileStream(yol,FileMode.Create));
            ViewData["mesaj"]="Dosya Yükleme Tamamlandı.";
        }
        
        int sayi1 =int.Parse(formgelen["s1"].ToString());
        int sayi2 =int.Parse(formgelen["s2"].ToString());
        ViewData["carp"]=sayi1*sayi2;
        ViewData["bol"]=sayi1/sayi2;
        ViewData["topla"]=sayi1+sayi2;
        ViewData["fark"]=sayi1-sayi2;

        return View();
    }

     public IActionResult KisiKayitIslem(IFormCollection f2)
    {
        if (ModelState.IsValid == true)
        {
            string s1 = f2["Ad"].ToString();
            string s2 = f2["Telefon"].ToString();

            SqlConnection baglan=new SqlConnection();
            baglan.ConnectionString="Server=(localdb)\\mssqllocaldb;Database=mtapaşa;Trusted_Connection=true;";
            baglan.Open();
            SqlCommand sql = new SqlCommand ("insert into telefon (ad,tel)values('"+s1+"','"+s2+"')",baglan);
            sql.ExecuteNonQuery();
            ViewData["mesaj"]="Kayıt Yapıldı.";

        return View();



        }
        else
        {
            return Content("Doğrulama işlemi başarısız.");
        }

    }

}

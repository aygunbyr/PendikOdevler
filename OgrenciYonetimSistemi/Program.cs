StudentManager studentManager = new StudentManager();

Student aygun = new Student()
{
    Isim = "Aygün",
    Soyisim = "Bayir",
    Yas = 29,
    Takim = "Türkiye Milli",
    ProgramlamaDilleri = new string[] { "JavaScript", "Java", "C#" },
    Telefon = "+905439062565",
    YabanciDilBiliyor = true,
    Semt = "Gebze"
};

studentManager.Add(aygun);
studentManager.Update(aygun);
studentManager.Remove(aygun);

class Student
{
    public string Isim;
    public string Soyisim;
    public int Yas;
    public string Takim;
    public string[] ProgramlamaDilleri;
    public string Telefon;
    public bool YabanciDilBiliyor;
    public string Semt;

    public Student() { }

    public Student(string isim, string soyisim, int yas, string takim, string[] programlamaDilleri, string telefon, bool yabanciDilBiliyor, string semt)
    {
        Isim = isim;
        Soyisim = soyisim;
        Yas = yas;
        Takim = takim;
        ProgramlamaDilleri = programlamaDilleri;
        Telefon = telefon;
        YabanciDilBiliyor = yabanciDilBiliyor;
        Semt = semt;
    }

    public override string ToString()
    {
        return $"Isim: {Isim}, Soyisim: {Soyisim}, Yas: {Yas}, Tuttugu takim: {Takim}, Programlama dilleri: {string.Join(",", ProgramlamaDilleri)}, Yabanci dil biliyor mu: {(YabanciDilBiliyor ? "Evet" : "Hayir")}, Semt: {Semt}";
    }
}

class StudentManager
{
    public StudentManager() { }

    private bool Validate(Student student)
    {
        if (student.Isim.Length < 2)
        {
            Console.WriteLine("Ogrenci adi en az 2 karakterden olusmalidir!");
            return false;
        }
        if (student.Soyisim.Length < 2)
        {
            Console.WriteLine("Ogrenci soyadi en az 2 karakterden olusmalidir!");
            return false;
        }
        if (student.ProgramlamaDilleri.Length < 1)
        {
            Console.WriteLine("Ogrenci en az bir programlama dili bilmelidir!");
            return false;
        }
        if (!(student.Yas >= 18 && student.Yas < 35))
        {
            Console.WriteLine("Ogrenci en az 18 yasinda olmali ve 35 yasindan kucuk olmalidir!");
            return false;
        }
        if (string.IsNullOrWhiteSpace(student.Telefon) || !student.Telefon.StartsWith("+905"))
        {
            Console.WriteLine("Ogrenci telefon numarasi bos olmamali ve +905 ile baslamalidir!");
            return false;
        }
        if (string.IsNullOrEmpty(student.Semt))
        {
            Console.WriteLine("Ogrenci semt bilgisi bos birakilamaz!");
            return false;
        }
        // Engelleri astik, mutlu sona ulastik!
        return true;
    }

    public void Add(Student student)
    {
        bool dogrulama = Validate(student);
        if (dogrulama)
        {
            Console.WriteLine("Ogrenci basariyla eklendi.");
            Console.WriteLine(student.ToString());
        }
    }

    public void Update(Student student)
    {
        bool dogrulama = Validate(student);
        if (dogrulama)
        {
            Console.WriteLine("Ogrenci basariyla guncellendi.");
            Console.WriteLine(student.ToString());
        }
    }

    public void Remove(Student student)
    {
        bool dogrulama = Validate(student);
        if (dogrulama)
        {
            Console.WriteLine("Ogrenci basariyla silindi.");
            Console.WriteLine(student.ToString());
        }
    }
}

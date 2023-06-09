using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

namespace NUO_TAISTELU;

public class NUO_TAISTELU : PhysicsGame
{
    private Double EVENT_INTERVAL = 6;
    private Vector ALOITUSKORTTI_POSITION = new Vector(100, - 55);
    Image tausta_uusi = LoadImage("tausta_uusi");
    Image olionKuva = LoadImage("olionKuva");
    Image viisi = LoadImage("viisi");
    Image failcard = LoadImage("failcard");
    Image kuusi = LoadImage("kuusi");
    Image kahdeksan = LoadImage("kahdeksan");
    Image ukko = LoadImage("ukko");
    Image NUO = LoadImage("NUO");
    Image nolla = LoadImage("nolla");
    Image phone = LoadImage("phone");
    Image puhe1 = LoadImage("puhe1");
    Image pistooli = LoadImage("pistooli");
    SoundEffect RAGE = LoadSoundEffect("RAGE");
    SoundEffect GUNLOAD = LoadSoundEffect("GUNLOAD");
    SoundEffect CRINTRO = LoadSoundEffect("CRINTRO");
    SoundEffect NOPE = LoadSoundEffect("NOPE");
    SoundEffect what = LoadSoundEffect("what");
    Image puhe2 = LoadImage("puhe2");
    SoundEffect collapse = LoadSoundEffect("collapse");
    Image ase2 = LoadImage("ase2");
    Image pelokas = LoadImage("pelokas");
    SoundEffect shot = LoadSoundEffect("shot");
    
    DoubleMeter alaspainlaskuri;
    Timer aikalaskuri;
    private int lasku2 = 1;

    private PhysicsObject kasi;
    private PhysicsObject äijä;
    
    void LuoAikalaskuri()
    {
        alaspainlaskuri = new DoubleMeter(EVENT_INTERVAL);
        
        aikalaskuri = new Timer();
        aikalaskuri.Interval = EVENT_INTERVAL;
        aikalaskuri.Timeout += LaskeAlaspain;
        aikalaskuri.SecondCounterStep = -1;
        aikalaskuri.Start();
        Label aikanaytto = new Label();
        aikanaytto.TextColor = Color.White;
        aikanaytto.DecimalPlaces = 1;
        aikanaytto.BindTo(aikalaskuri.SecondCounter);
        aikanaytto.X = 670;
        aikanaytto.Y = 370;
        Add(aikanaytto, 1);
        
        
    }
    void LaskeAlaspain()
    {
        aikalaskuri.SecondCounter.Reset();
        switch (lasku2)
        {
            case 1:
                kasi.Image = phone;
                CRINTRO.Play();
                break;
            case 2: 
                äijä.Image = puhe1;
                RAGE.Play();
                break;
            case 3:
                PhysicsObject ase = new PhysicsObject(100, 160);
        
                ase.X = ase.X - 120;
                ase.Y = ase.Y + 200;
        
                ase.Image = pistooli;

                Add(ase);
                ase.Angle = Angle.FromDegrees(14);
                GUNLOAD.Play();
                break;
            case 4:
                shot.Play();
                var rajahdys = new Explosion(900);
                rajahdys.Position = new Vector(+ 100, - 20);
                rajahdys.UseShockWave = true;
                Add(rajahdys);
                break;
        }
        kasi.Image = phone;
        ukko = puhe1;
        lasku2++;
    }

    private void LuoKentta()
    {
        Level.CreateBottomBorder();
        
        LuoAikalaskuri();
        
        Level.Background.Image = tausta_uusi;
        Level.Background.ScaleToLevelFull();
        IsFullScreen = true;

        Camera.ZoomToLevel();
        double paikka = - 100;
        LuoKortti(kuusi,paikka, "kuusi");
        double paikkamuutos = 170;
        paikka = paikka + paikkamuutos;
        LuoKortti(failcard,paikka, "failcard");
        paikka = paikka + paikkamuutos;
        LuoKortti(kahdeksan,paikka, "kahdeksan");
        paikka = paikka + paikkamuutos;
        LuoKortti(viisi,paikka, "viisi");
        
        kasi = new PhysicsObject(200, 400);
        
        kasi.X = kasi.X + 600;
        kasi.Y = kasi.Y - 200;
        
        kasi.Image = olionKuva;

        Add(kasi);
        
        äijä = new PhysicsObject(400, 413);
        
        äijä.X = äijä.X + - 400;
        äijä.Y = äijä.Y + 200;
        
        äijä.Image = ukko;

        Add(äijä);
        äijä.Angle = Angle.FromDegrees(14);
        
        PhysicsObject pakka = new PhysicsObject(100, 160);

        pakka.Position = new Vector(250, -20);

        pakka.Image = NUO;
        pakka.IgnoresCollisionResponse = true;

        Add(pakka);
        pakka.Angle = Angle.FromDegrees(14);
        
        PhysicsObject aloitusKortti = new PhysicsObject(100, 160);

        aloitusKortti.Position = ALOITUSKORTTI_POSITION;
        aloitusKortti.Tag = "nolla";
        aloitusKortti.Image = nolla;

        Add(aloitusKortti);
        Mouse.ListenOn(aloitusKortti, HoverState.On, MouseButton.Left, ButtonState.Pressed, delegate { Siirto(aloitusKortti); }, "siirtää korttia");
        aloitusKortti.Angle = Angle.FromDegrees(14);
        
       
    }

    private void LuoKortti(Image image, double paikka, string tag)
    {

        PhysicsObject kortti = new PhysicsObject(100, 160);
        
        kortti.X =  paikka;
        kortti.Y =   - 300;
        kortti.Tag = tag;
        kortti.Color = Color.Red;
        kortti.Image = image;
        Add(kortti, 1);
        
        Mouse.ListenOn(kortti, HoverState.On, MouseButton.Left, ButtonState.Pressed, delegate { Siirto(kortti); }, "siirtää korttia");
    }

    private void Siirto(PhysicsObject kortti)
    {
        aikalaskuri.Reset();
        switch (kortti.Tag)
        {
            case"kuusi":
                kortti.Position = RandomGen.NextVector(-300, -300, 300, 300);
                kortti.IgnoresCollisionResponse = true;
                NOPE.Play();
                break;
            case"failcard":
                if(kortti.Position ==ALOITUSKORTTI_POSITION)break;
                kortti.Position = ALOITUSKORTTI_POSITION;
                kortti.IgnoresCollisionResponse = true;
                kortti.Angle = Angle.FromDegrees(14);
                what.Play();
                äijä.Image = puhe2;
                for (int i = 0; i < 100; i++)
                {
                    var rajahdys = new Explosion(9000);
                    rajahdys.Position = RandomGen.NextVector(-800, -800, 800, 800);
                    rajahdys.UseShockWave = true;
                    Add(rajahdys);
                }

                break;
            case"viisi":
                Gravity = new Vector(0.0, -281.0);
                collapse.Play();
                break;
            case"kahdeksan":
                if(kortti.Position ==ALOITUSKORTTI_POSITION)break;
                kortti.Position = ALOITUSKORTTI_POSITION;
                kortti.IgnoresCollisionResponse = true;
                kortti.Angle = Angle.FromDegrees(14);
                break;
            case "nolla":
                for (int i = 0; i < 100; i++)
                {
                    kortti.Destroy();
                    PhysicsObject palikka = new PhysicsObject(20, 25);
                    palikka.Image = nolla;
                    Add(palikka);
                    palikka.Color = Color.Blue;
                }
                break;
        }
        
    }

    public override void Begin()
    {
        LuoKentta();
        
        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
        
        
    }
    
    
}
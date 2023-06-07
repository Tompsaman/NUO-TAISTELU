using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Widgets;

namespace NUO_TAISTELU;

public class NUO_TAISTELU : PhysicsGame
{
    Image tausta_uusi = LoadImage("tausta_uusi");
    Image olionKuva = LoadImage("olionKuva");
    Image viisi = LoadImage("viisi");
    Image failcard = LoadImage("failcard");
    Image kuusi = LoadImage("kuusi");
    Image kahdeksan = LoadImage("kahdeksan");
    Image ukko = LoadImage("ukko");
    private Image NUO = LoadImage("NUO");

    private void LuoKentta()
    {
        Level.Background.Image = tausta_uusi;
        Level.Background.ScaleToLevelFull();
        IsFullScreen = true;

        Camera.ZoomToLevel();
        double paikka = - 100;
        LuoKortti(kuusi,paikka);
        double paikkamuutos = 170;
        paikka = paikka + paikkamuutos;
        LuoKortti(failcard,paikka);
        paikka = paikka + paikkamuutos;
        LuoKortti(kahdeksan,paikka);
        paikka = paikka + paikkamuutos;
        LuoKortti(viisi,paikka);
    }

    private void LuoKortti(Image image, double paikka)
    {
        PhysicsObject Kortti = new PhysicsObject(100, 160);
        
        Kortti.X =  paikka;
        Kortti.Y =   - 300;
        
        Kortti.Color = Color.Red;
        Kortti.Image = image;
        Add(Kortti);
    }
    public override void Begin()
    {
        LuoKentta();
        
        PhysicsObject kasi = new PhysicsObject(200, 400);
        
        kasi.X = kasi.X + 600;
        kasi.Y = kasi.Y - 300;
        
        kasi.Image = olionKuva;

        Add(kasi);
        
        PhysicsObject äijä = new PhysicsObject(400, 413);
        
        äijä.X = äijä.X + - 400;
        äijä.Y = äijä.Y + 200;
        
        äijä.Image = ukko;

        Add(äijä);
        äijä.Angle = Angle.FromDegrees(14);
        
        PhysicsObject pakka = new PhysicsObject(100, 160);
        
        pakka.X = pakka.X + - 0;
        pakka.Y = pakka.Y + 0;
        
        pakka.Image = NUO;

        Add(pakka);
        pakka.Angle = Angle.FromDegrees(14);

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
        
        
    }
    
    
}
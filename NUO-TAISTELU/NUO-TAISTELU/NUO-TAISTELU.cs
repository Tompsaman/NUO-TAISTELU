using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Widgets;

namespace NUO_TAISTELU;

public class NUO_TAISTELU : PhysicsGame
{
    Image tausta = LoadImage("tausta");
    Image olionKuva = LoadImage("olionKuva");
    Image viisi = LoadImage("viisi");
    Image failcard = LoadImage("failcard");
    Image kuusi = LoadImage("kuusi");
    Image kahdeksan = LoadImage("kahdeksan");

    private void LuoKentta()
    {
        Level.Background.Image = tausta;
        Level.Background.ScaleToLevelFull();
        IsFullScreen = true;

        Camera.ZoomToLevel();
        double paikka = 140;
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
        
        PhysicsObject kasi = new PhysicsObject(270, 480);
        
        kasi.X = kasi.X + 830;
        kasi.Y = kasi.Y - 350;
        
        kasi.Image = olionKuva;

        Add(kasi);

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
        
        
    }
    
    
}
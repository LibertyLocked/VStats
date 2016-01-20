﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VStats_plugin
{
    /// <summary>
    /// Hashes for weapon models
    /// Because Script Hook V .NET 2.4 doesn't have hashes for DLC weapons,
    /// this substitudes GTA.Native.WeaponHash until the hook is updated.
    /// </summary>
    enum WeaponHash : uint
    {
        Knife = 0x99B507EA,
        Nightstick = 0x678B81B1,
        Hammer = 0x4E875F73,
        Bat = 0x958A4A8F,
        GolfClub = 0x440E4788,
        Crowbar = 0x84BD7BFD,
        Bottle = 0xF9E6AA4B,
        SwitchBlade = 0xDFE37640,
        Pistol = 0x1B06D571,
        CombatPistol = 0x5EF9FEC4,
        APPistol = 0x22D8FE39,
        Pistol50 = 0x99AEEB3B,
        FlareGun = 0x47757124,
        MarksmanPistol = 0xDC4DB296,
        Revolver = 0xC1B3C3D1,
        MicroSMG = 0x13532244,
        SMG = 0x2BE6766B,
        AssaultSMG = 0xEFE7E2DF,
        CombatPDW = 0x0A3D4D34,
        AssaultRifle = 0xBFEFFF6D,
        CarbineRifle = 0x83BF0278,
        AdvancedRifle = 0xAF113F99,
        MG = 0x9D07F764,
        CombatMG = 0x7FD62962,
        PumpShotgun = 0x1D073A89,
        SawnOffShotgun = 0x7846A318,
        AssaultShotgun = 0xE284C527,
        BullpupShotgun = 0x9D61E50F,
        StunGun = 0x3656C8C1,
        SniperRifle = 0x5FC3C11,
        HeavySniper = 0xC472FE2,
        GrenadeLauncher = 0xA284510B,
        GrenadeLauncherSmoke = 0x4DD2DC56,
        RPG = 0xB1CA77B1,
        Minigun = 0x42BF8A85,
        Grenade = 0x93E220BD,
        StickyBomb = 0x2C3731D9,
        SmokeGrenade = 0xFDBC8A50,
        BZGas = 0xA0973D5E,
        Molotov = 0x24B17070,
        FireExtinguisher = 0x60EC506,
        PetrolCan = 0x34A67B97,
        SNSPistol = 0xBFD21232,
        SpecialCarbine = 0xC0A3098D,
        HeavyPistol = 0xD205520E,
        BullpupRifle = 0x7F229F94,
        HomingLauncher = 0x63AB0442,
        ProximityMine = 0xAB564B93,
        Snowball = 0x787F0BB,
        VintagePistol = 0x83839C4,
        Dagger = 0x92A27487,
        Firework = 0x7F7497E5,
        Musket = 0xA89CB99E,
        MarksmanRifle = 0xC734385A,
        HeavyShotgun = 0x3AABBBAA,
        Gusenberg = 0x61012683,
        Hatchet = 0xF9DCBF2D,
        Railgun = 0x6D544C99,
        Unarmed = 0xA2719263,
        KnuckleDuster = 0xD8DF3C3C,
        Machete = 0xDD5DF8D9,
        MachinePistol = 0xDB1AA450,
        Flashlight = 0x8BB05FD7,

        // Added by libertylocked
        Ball = 0x23C9F95C,
        Flare = 0x497FACC3,
    }
}

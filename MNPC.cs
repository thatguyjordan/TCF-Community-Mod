using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using TAPI;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace tcfcomm
{
    [GlobalMod]
    public sealed class MNPC : ModNPC
    {
        public override void Initialize()
        {
            DateTime now = DateTime.Now;
            int day = now.Day;
            int month = now.Month;
            bool red = now.Day == 12 && now.Month == 11;
            bool jordan = now.Day == 3 && now.Month == 7;
            bool neal = now.Day == 27 && now.Month == 7;
//            bool cireus = now.Day == 0 && now.Month == 0;
            if (npc.type == 4)
            {
                npc.height = 110;
                npc.width = 110;
            }
            if (red || jordan || neal && npc.type == 113)
            {
                npc.displayName = "Wall Of Cake"; //on specified dates change wall of flesh name to wall of cake
            }
            else if (red || jordan || neal && npc.type == 114)
            {
                npc.displayName = "Wall Of Cake Candle"; //on specified dates change wall of flesh name to wall of cake candle
            }
            else if (red || jordan || neal && npc.type == 115 || npc.type == 116)
            {
                npc.displayName = "Cupcake"; //on specified dates change hungry name to cupcake
            }
            else if (red || jordan || neal && npc.type == 117 || npc.type == 118 || npc.type == 119)
            {
                npc.displayName = "Gummy Worm"; //on specified dates change leech name to gummy worm
            }
        }
        public override void PostNPCLoot()
        {
            int pg = ItemDef.byName["tcfcomm:Pink Gel"].type; //defines item as an integer
            int X = (int)npc.position.X;
            int Y = (int)npc.position.Y;

            if ((npc.netID == -4) && Main.rand.Next(1) == 0)
            {
                Item.NewItem(X, Y, npc.width, npc.height, pg, Main.rand.Next(40, 101), false, 0, false); //spawns pink gel from pinky, 40 - 100 per time
            }
            if ((npc.type == 50) && Main.rand.Next(25) == 0)
            {
                Item.NewItem(X, Y, npc.width, npc.height, ItemDef.byType[1309].type, 1, false, 0, false); //numerous suggestions based around slime staff drop rate
            } /*
            if (npc.type == 85 && npc.ai[3] == 3f && Main.rand.Next(1) == 0) //shadow mimic id
            {
                Item.NewItem(X, Y, npc.width, npc.height, ItemDef.byType[274].type, 1, false, 0, false); //drops dark lance off shadow mimic
            } */
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

using TAPI;
using Terraria;

namespace tcfcomm.Projectiles
{
    public class BBombProj : ModProjectile
    {
        public override void PostAI()
        {
            if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
            {
                int num373 = Gore.NewGore(new Vector2(projectile.position.X - 9f, projectile.position.Y - 9f), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num373].velocity *= 0.4f;
                Gore gore85 = Main.gore[num373];
                gore85.velocity.X = gore85.velocity.X + 1f;
                Gore gore86 = Main.gore[num373];
                gore86.velocity.Y = gore86.velocity.Y + 1f;
                num373 = Gore.NewGore(new Vector2(projectile.position.X - 9f, projectile.position.Y - 9f), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num373].velocity *= 0.4f;
                Gore gore87 = Main.gore[num373];
                gore87.velocity.X = gore87.velocity.X - 1f;
                Gore gore88 = Main.gore[num373];
                gore88.velocity.Y = gore88.velocity.Y + 1f;
                num373 = Gore.NewGore(new Vector2(projectile.position.X - 9f, projectile.position.Y - 9f), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num373].velocity *= 0.4f;
                Gore gore89 = Main.gore[num373];
                gore89.velocity.X = gore89.velocity.X + 1f;
                Gore gore90 = Main.gore[num373];
                gore90.velocity.Y = gore90.velocity.Y - 1f;
                num373 = Gore.NewGore(new Vector2(projectile.position.X - 9f, projectile.position.Y - 9f), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num373].velocity *= 0.4f;
                Gore gore91 = Main.gore[num373];
                gore91.velocity.X = gore91.velocity.X - 1f;
                Gore gore92 = Main.gore[num373];
                gore92.velocity.Y = gore92.velocity.Y - 1f;
            }
        }
        public override void PostKill()
        {
            int expl = ProjDef.byName["tcfcomm:Explosion"].type;
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, expl, 100, 0, projectile.whoAmI);
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 22;
            projectile.height = 22;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            {
                int i = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[i].velocity *= 1.4f;
            }
            {
                float num404 = projectile.position.X;
                float num415 = num404 - (projectile.position.X + (float)(projectile.width / 2));
                num415 = 4;
                int num416 = (int)(projectile.position.X / 16f - (float)num415);
			    int num417 = (int)(projectile.position.X / 16f + (float)num415);
			    int num418 = (int)(projectile.position.Y / 16f - (float)num415);
			    int num419 = (int)(projectile.position.Y / 16f + (float)num415);
			    if (num416 < 0)
					{
						num416 = 0;
					}
					if (num417 > Main.maxTilesX)
					{
						num417 = Main.maxTilesX;
					}
					if (num418 < 0)
					{
						num418 = 0;
					}
					if (num419 > Main.maxTilesY)
					{
						num419 = Main.maxTilesY;
					}
					bool flag2 = false;
					for (int num420 = num416; num420 <= num417; num420++)
					{
						for (int num421 = num418; num421 <= num419; num421++)
						{
                            float num422 = System.Math.Abs((float)num420 - projectile.position.X / 16f);
                            float num423 = System.Math.Abs((float)num421 - projectile.position.Y / 16f);
							double num424 = System.Math.Sqrt((double)(num422 * num422 + num423 * num423));
							if (num424 < (double)num415 && Main.tile[num420, num421] != null && Main.tile[num420, num421].wall == 0)
							{
								flag2 = true;
								break;
							}
						}
					}
					for (int num425 = num416; num425 <= num417; num425++)
					{
						for (int num426 = num418; num426 <= num419; num426++)
						{
                            float num427 = System.Math.Abs((float)num425 - projectile.position.X / 16f);
                            float num428 = System.Math.Abs((float)num426 - projectile.position.Y / 16f);
							double num429 = System.Math.Sqrt((double)(num427 * num427 + num428 * num428));
							if (num429 < (double)num415)
							{
								bool flag3 = true;
								if (Main.tile[num425, num426] != null && Main.tile[num425, num426].active())
								{
									flag3 = true;
									if (TileDef.tileDungeon[(int)Main.tile[num425, num426].type] || Main.tile[num425, num426].type == 21 || Main.tile[num425, num426].type == 26 || Main.tile[num425, num426].type == 107 || Main.tile[num425, num426].type == 108 || Main.tile[num425, num426].type == 111 || Main.tile[num425, num426].type == 226 || Main.tile[num425, num426].type == 237 || Main.tile[num425, num426].type == 221 || Main.tile[num425, num426].type == 222 || Main.tile[num425, num426].type == 223 || Main.tile[num425, num426].type == 211)
									{
										flag3 = false;
									}
									if (!Main.hardMode && Main.tile[num425, num426].type == 58)
									{
										flag3 = false;
									}
									if (flag3)
									{
										WorldGen.KillTile(num425, num426, false, false, false);
										if (!Main.tile[num425, num426].active() && Main.netMode != 0)
										{
											NetMessage.SendData(17, -1, -1, "", 0, (float)num425, (float)num426, 0f, 0f);
										}
									}
								}
								if (flag3)
								{
									for (int num430 = num425 - 1; num430 <= num425 + 1; num430++)
									{
										for (int num431 = num426 - 1; num431 <= num426 + 1; num431++)
										{
											if (Main.tile[num430, num431] != null && Main.tile[num430, num431].wall > 0 && flag2)
											{
												WorldGen.KillWall(num430, num431, false);
												if (Main.tile[num430, num431].wall == 0 && Main.netMode != 0)
												{
													NetMessage.SendData(17, -1, -1, "", 2, (float)num430, (float)num431, 0f, 0f);
												}
											}
										}
									}
								}
							}
						}
					}
				}
				if (Main.netMode != 0)
				{
                    NetMessage.SendData(29, -1, -1, "", projectile.identity, (float)projectile.owner, 0f, 0f, 0f);
				}
                if (!projectile.noDropItem)
                {
                    int num432 = -1;
                    if (projectile.aiStyle == 10)
                    {
                        int num433 = (int)(projectile.position.X + (float)(projectile.width / 2)) / 16;
                        int num434 = (int)(projectile.position.Y + (float)(projectile.width / 2)) / 16;
                        int num435 = 0;
                        int num436 = 2;
                        if (Main.tile[num433, num434].halfBrick() && projectile.velocity.Y > 0f && System.Math.Abs(projectile.velocity.Y) > System.Math.Abs(projectile.velocity.X))
                        {
                            num434--;
                        }
                        if (!Main.tile[num433, num434].active())
                        {
                            WorldGen.PlaceTile(num433, num434, num435, false, true, -1, 0);
                            if (Main.tile[num433, num434].active() && (int)Main.tile[num433, num434].type == num435)
                            {
                                if (Main.tile[num433, num434 + 1].halfBrick() || Main.tile[num433, num434 + 1].slope() != 0)
                                {
                                    WorldGen.SlopeTile(num433, num434 + 1, 0);
                                    if (Main.netMode == 2)
                                    {
                                        NetMessage.SendData(17, -1, -1, "", 14, (float)num433, (float)(num434 + 1), 0f, 0f);
                                    }
                                }
                                if (Main.netMode != 0)
                                {
                                    NetMessage.SendData(17, -1, -1, "", 1, (float)num433, (float)num434, (float)num435, 0f);
                                }
                            }
                            else if (num436 > 0)
                            {
                                num432 = Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, num436, 1, false, 0, false);
                            }
                        }
                        else if (num436 > 0)
                        {
                            num432 = Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, num436, 1, false, 0, false);
                        }
                    }
                }
        }
    }
}
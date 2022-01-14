using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BrandensMod.Items.Weapons.Swords.DebugSword
{
	public class DebugSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("DefaultSword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("You shouldn't have this...");
		}

		public override void SetDefaults() 
		{
			item.damage = 200;
			item.melee = true;
			item.width = 54;
			item.height = 54;
			item.useTime = 10;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 25;
			item.value = 10000;
			item.rare = ItemRarityID.Expert;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			int ATH = damage / 2;
			player.statLife += ATH;
			player.HealEffect(ATH); // Heal indicator

			if (player.statLife > player.statLifeMax2)
			{
				player.statLife = player.statLifeMax2; // Prevent "over healing"
			}
			target.AddBuff(BuffID.ShadowFlame, 600);
		}
	}
}
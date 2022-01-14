using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BrandensMod.Items.Weapons.Swords.BloodSword
{
	public class BloodSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("DefaultSword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("A sword forged by blood\n\nHeals half damage per hit\n\nApplies burning on hit");
		}

		public override void SetDefaults() 
		{
			item.damage = 55;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Vertebrae, 10);
			recipe.AddIngredient(ItemID.LifeCrystal, 15);
			recipe.AddIngredient(ItemID.Obsidian, 25);
			recipe.AddIngredient(ItemID.CrimtaneBar, 20);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
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
			target.AddBuff(BuffID.OnFire, 60);
		}
	}
}
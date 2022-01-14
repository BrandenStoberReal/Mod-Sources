using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BrandensMod.Items.Tools.Pickaxes.DebugPickaxe
{
    class DebugPickaxe : ModItem
    {
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("You shouldn't have this...");
		}

		public override void SetDefaults()
		{
			item.damage = 20;
			item.melee = true;
			item.width = 38;
			item.height = 38;
			item.useTime = 1;
			item.useAnimation = 5;
			item.pick = 300;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 20;
			item.value = 10000;
			item.rare = ItemRarityID.Expert;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Shadowflame);
		}
	}
}

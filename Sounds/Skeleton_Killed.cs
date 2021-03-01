using Microsoft.Xna.Framework.Audio;
using Terraria;
using Terraria.ModLoader;

namespace MrPlagueRaces.Sounds
{
	public class Skeleton_Killed : ModSound
	{
		public override SoundEffectInstance PlaySound(ref SoundEffectInstance soundInstance, float volume, float pan, SoundType type) 
		{
			soundInstance = sound.CreateInstance();
			soundInstance.Pan = pan;
			soundInstance.Pitch = Main.rand.Next(-3, 1) * .05f;
			return soundInstance;
		}
	}
}

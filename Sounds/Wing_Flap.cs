using Microsoft.Xna.Framework.Audio;
using Terraria;
using Terraria.ModLoader;

namespace MrPlagueRaces.Sounds
{
	public class Wing_Flap : ModSound
	{
		public override SoundEffectInstance PlaySound(ref SoundEffectInstance soundInstance, float volume, float pan, SoundType type) 
		{
			soundInstance = sound.CreateInstance();
			soundInstance.Pan = pan;
			return soundInstance;
		}
	}
}

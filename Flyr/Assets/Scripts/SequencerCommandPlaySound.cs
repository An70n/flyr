using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
    public class SequencerCommandPlaySound : SequencerCommand
    {
        public void Awake()
        {
            AudioManager.audioManager.Play(GetParameter(0));
            Stop();
        }
    }
}

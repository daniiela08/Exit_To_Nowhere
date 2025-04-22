using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Subtitle Data") ]
public class SubtitleDataSO : ScriptableObject
{
    [System.Serializable]

    public class SubtitleEntry
    {
        public string id;
        [TextArea]
        public List<string> subtitleTexts;
        public float timePerSubtitle;
    }

    public List<SubtitleEntry> subtitles = new List<SubtitleEntry>();

    public SubtitleEntry GetSubtitleById(string id)
    {
        return subtitles.Find(entry => entry.id == id);
    }
}

using System.Collections;
using System.Collections.Generic;
// using UnityEngine;

namespace IcedCoffee
{
    [System.Serializable]
    public class MusicLoader
    {
        [UnityEngine.SerializeField]
        private readonly string _path = null;
        [UnityEngine.SerializeField]
        private List<UnityEngine.AudioClip> _audioData = null;

        public MusicLoader()
        {
            this._path = UnityEngine.Application.streamingAssetsPath;
            this._audioData = new List<UnityEngine.AudioClip>();
        }

        public MusicLoader(string path)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(UnityEngine.Application.streamingAssetsPath);
            this._path = sb.Append(path).ToString();
            this._audioData = new List<UnityEngine.AudioClip>();
        }

        /**
         * <summary>
         * Loads in audio files from a set path.
         * </summary>
         */
        public void Load()
        {
            
        }

        /**
         * <summary>
         * Returns the base file path from which audio files will be looked for.
         * </summary>
         */
        public string DataPath
        {
            get
            {
                return this._path;
            }
        }

        public List<UnityEngine.AudioClip> Soundtrack
        {
            get
            {
                return this._audioData;
            }
        }

        public IEnumerator LoadFilesFromDisk(string fileName, System.Action onComplete)
        {
            UnityEngine.Networking.UnityWebRequest req = UnityEngine
                .Networking
                .UnityWebRequestMultimedia
                .GetAudioClip("file://" + this._path + "/" + fileName + ".ogg", UnityEngine.AudioType.OGGVORBIS);
            yield return req.SendWebRequest();
            if (req.isNetworkError || req.isHttpError)
            {
                throw new System.Exception("Response Code: " + req.responseCode + " while fetching " + req.uri);
            }
            else if (req.isDone)
            {
                this._audioData.Add(((UnityEngine.Networking.DownloadHandlerAudioClip)req.downloadHandler).audioClip);
                onComplete();
            }
        }

        /**
         * <summary>
         * Returns the name of all files found with the soundtrack directory.
         * </summary>
         */
        public List<string> LoadAudioFileNames()
        {
            List<System.IO.FileInfo> fileList = new List<System.IO.FileInfo>();
            string[] fileNames = System.IO.Directory.GetFiles(this._path, "*.ogg", System.IO.SearchOption.TopDirectoryOnly);
            List<string> files = new List<string>();

            foreach (string fileName in fileNames)
            {
                fileList.Add(new System.IO.FileInfo(fileName));
            }

            fileList.ForEach((System.IO.FileInfo f) =>
            {
                files.Add(f.Name.Replace(".ogg", ""));
            });

            return files;
        }
    }
}

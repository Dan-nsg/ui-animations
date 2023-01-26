using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plataformer2D.Core.Singleton;


namespace Screens 
{

    public class ScreenManager : Singleton<ScreenManager>
    {
        public List<ScreenBase> screenBases;

        public List<GameObject> objs;

        public ScreenType startScreen = ScreenType.Panel;

        private ScreenBase _currentScreen;

        public Vector3 vec;

        private void Start() 
        {
            HideAll();
            ShowByType(startScreen);
        }

        private void GetRamdom()
        {
           screenBases[Random.Range(0, screenBases.Count)].animationDuration = 1;
        }

        public void ShowByType(ScreenType type)
        {
            if(_currentScreen != null) _currentScreen.Hide();

            var nextScreen = screenBases.Find(i => i.screenType == type);

            nextScreen.Show();
            _currentScreen = nextScreen;
        }

        public void HideAll()
        {
            screenBases.ForEach(i => i.Hide());
        }
    }
}

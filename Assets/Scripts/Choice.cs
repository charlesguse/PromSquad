using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Scene
{
    public class Choice : MonoBehaviour
    {
        public static int ChoiceMade { get; set; }

        static Choice()
        {
            ChoiceMade = -1;
        }


        // ReSharper disable once UnusedMember.Local
        void Start()
        {

        }

        // ReSharper disable once UnusedMember.Local
        void Update()
        {

        }

        public void Choose()
        {
            ChoiceMade = int.Parse(name.Split(' ')[1]);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace TheKiwiCoder {
    [System.Serializable]
    public class RandomSelector : CompositeNode {
        protected int current;
        public bool canRepeatSame = true;
        //To keep record of num of times a child is run
        private List<int> childHit = new List<int>();

        protected override void OnStart() {
            current = Random.Range(0, children.Count);
            //Create num of array cells based on num of children
            while(childHit.Count < children.Count) childHit.Add(0);

            if(!canRepeatSame) UseLeastSelectedChild();
            //Also increase the currently selected child count by 1 in childHit
            childHit[current]+=1;
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            var child = children[current];
            return child.Update();
        }

        //Will randomly select the least selected child
        void UseLeastSelectedChild(){
            float averageHit = 0;
            foreach(int hitCount in childHit){
                averageHit += hitCount;
            }
            averageHit = averageHit/childHit.Count;

            //Keep randomly selecting until a child that is on avg. not selected much is selected
            while(childHit[current] > averageHit){
                current = Random.Range(0, children.Count);
            }
        }
    }
}
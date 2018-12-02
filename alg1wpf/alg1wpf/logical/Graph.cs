using System;
using System.Collections.Generic;

namespace alg1wpf.logical
{
    public abstract class Graph
    {
        #region consts
        protected const int sizeHeap = 7;

        protected const int infinity = 1000001;

        protected const int minWeightOfEdge = 1;

        protected const int maxWeightOfEdge = 1000000;

        protected const int countNodeForExperiments = 10000;

        protected const int firstMinCountEdge = 100000;

        protected const int firstMaxCountEdge = 10000000;

        protected const int firstStep = 100000;

        protected const int secondStep = 1000;

        protected const int secondMinCountEdge = 1000;

        protected const int secondMaxCountEdge = 100000;
        #endregion

        public abstract List<int> FirstExperimentForFirstMethod();

        public abstract List<int> FirstExperimentForSecondMethod();

        public abstract List<int> SecondExperimentForFirstMethod();

        public abstract List<int> SecondExperimentForSecondMethod();
    }
}

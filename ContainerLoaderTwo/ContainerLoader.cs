namespace ContainerLoaderTwo
{
    public class ContainerLoader
    {

        private List<Stack<char>> listOfContainerStacks;
        private Stack<char> containerStack;

        public ContainerLoader()
        {
            listOfContainerStacks = new List<Stack<char>>();
            containerStack = new Stack<char>();
        }

        public int GetMinimunNumberOfContainerStacks(string containers)
        {
            if (string.IsNullOrEmpty(containers))
            {
                return 0;
            }

            return GetNumberOfStacks(containers);

        }

        public int GetNumberOfStacks(string containerArrival)
        {
            for (int letterIndex = 0; letterIndex < containerArrival.Length; letterIndex++)
            {
                if (letterIndex == 0)
                {
                    containerStack.Push(containerArrival[letterIndex]);
                    listOfContainerStacks.Add(containerStack);
                }
                else
                {
                    AddToTheRightContainerStack(containerArrival, containerArrival[letterIndex]);
                }
            }

            return listOfContainerStacks.Count;
        }

        public void AddToTheRightContainerStack(string containerToStack, char letterToStack)
        {
            for (int stackIndex = 0; stackIndex < listOfContainerStacks.Count; stackIndex++)
            {
                if (listOfContainerStacks[stackIndex].Peek() >= letterToStack )
                {
                    listOfContainerStacks[stackIndex].Push(letterToStack);
                    break;
                }
                if (letterToStack > listOfContainerStacks[stackIndex].Peek())
                {
                    containerStack.Push(letterToStack);
                    listOfContainerStacks.Add(containerStack);
                    break;
                }
            }
        }
    }
}

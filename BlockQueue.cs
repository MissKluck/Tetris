using System;

namespace Tetris
{
    /*
    This class will be responsible for picking the next block in the game
    It will contain a block array with an instnce of the 7 block classes which we will recycle 
    */
    public class BlockQueue
    {
        private readonly Block[] blocks = new Block[]
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock()
        };

        //add a random object
        private readonly Random random = new Random();

        //add a property for the next block in the queue --> when we write the ui we will preview this brick so the player knows whats coming --> you could also store an array here containing the next few blocks and preview all of them
        public Block NextBlock { get; private set; }

        //in the constructor we initialise the next block with a random block
        public BlockQueue()
        {
            NextBlock = RandomBlock();
        }

        //add a method which returns a random block
        private Block RandomBlock()
        {
            return blocks[random.Next(blocks.Length)];
        }

        //add a method that returns the next block and updates teh property (since we don't want to return the same block twice in a row we keep picking until we get a new one)
        public Block GetAndUpdate()
        {
            Block block = NextBlock;

            do
            {
                NextBlock = RandomBlock();
            } while (block.Id == NextBlock.Id);

            return block;
        }

    }
}
//This script is for custom enum types we can use throughout the project, to use them just type...
// using EventTypes; 
// at the top of your script.

namespace EventTypes
{
    public enum MOVEMENT
    {
        up,
        down,
        left,
        right
    }

    public enum RESOURCETYPE
    {
        hunger,
        thirst,
        stone,
        wood
    }

    public enum PLAYERSTATE
    {
        walking,
        gathering,
        attacking
    }
}

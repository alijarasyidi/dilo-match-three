public class GumTileEvent : TileEvent
{
    private int nilai;

    public GumTileEvent (int value)
    {
        nilai = value;
    }
    
    //Apa yang terjadi jika tile match
    public override void OnMatch()
    {

    }

    //Check jika persyaratn event telah terpenuhi
    public override bool AchievementCompleted()
    {
        return false;
    }
}
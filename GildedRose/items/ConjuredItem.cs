namespace GildedRose; 

public class ConjuredItem : Item{
     public override void UpdateQuality(){
    if(Quality==0 || Quality>49){return;}
        if(SellIn<0) Quality=Quality-2;
        Quality=Quality-2;
    }
    public override void UpdateSellin(){
        SellIn=SellIn-1;
    }  
}
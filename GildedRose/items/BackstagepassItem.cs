namespace GildedRose; 

public class BackstagepassItem : Item{
    
    public override void UpdateQuality(){
    switch (SellIn)
    {
        case <0:
        Quality = 0;
        break; 
        case <5:
        Quality=Quality+3;
        break;
        case <10: 
        Quality=Quality+2; 
        break; 
        default:
        Quality++;
        break; 
    }
    if(Quality>50) Quality=50;
    }
    public override void UpdateSellin(){
        this.SellIn=SellIn-1;
    }
}
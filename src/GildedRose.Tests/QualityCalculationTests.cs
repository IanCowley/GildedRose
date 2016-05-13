using GildedRose.Console;

using Narrative;

using Xunit;

namespace GildedRose.Tests
{
    public class QualityCalculationTests
    {
        [Fact]
        public void GIVEN_Item_Is_Before_Sell_By_Date_WHEN_UpdateQuality_THEN_Lowers_Quality_AND_Sellin()
        {
            var item = new Item();
            var quality = 2;
            var sellin = 2;
            var expectedQuality = 1;
            var expectedSellin = 1;

            Story.Given("Item has not reached sell by date", () => this.PopulateItem(item, quality, sellin))
                .When("Update Quality", () => this.RunProgram(item))
                .Then("Quality is lowered", () => this.QualityIs(item, expectedQuality))
                .And("Sellin is lowered", () => this.SellinIs(item, expectedSellin))
                .Start();
        }

        [Fact]
        public void GIVEN_Item_Has_Passed_Sell_By_Date_WHEN_UpdateQuality_THEN_Quality_Degrades_Twice_As_Fast()
        {
            var item = new Item();
            var quality = 3;
            var sellin = -1;
            var expectedQuality = 1;
            var expectedSellin = -2;

            Story.Given("Item has passed sell by date", () => this.PopulateItem(item, quality, sellin))
                .When("Update Quality", () => this.RunProgram(item))
                .Then("Quality degrades twice as fast", () => this.QualityIs(item, expectedQuality))
                .And("Sellin is lowered", () => this.SellinIs(item, expectedSellin))
                .Start();
        }

        [Fact]
        public void GIVEN_Item_Has_A_Quality_Of_Zero_WHEN_UpdateQuality_THEN_Quality_Does_Not_Go_Below_Zero()
        {
            var item = new Item();
            var quality = 0;
            var sellin = 1;
            var expectedQuality = 0;

            Story.Given("Item has passed sell by date", () => this.PopulateItem(item, quality, sellin))
                .When("Update Quality", () => this.RunProgram(item))
                .Then("Quality does not go below zero", () => this.QualityIs(item, expectedQuality))
                .Start();
        }

        [Fact]
        public void GIVEN_Item_Is_Brie_WHEN_UpdateQuality_THEN_Quality_Increases()
        {
            var item = new Item();
            var quality = 1;
            var sellin = 1;
            var expectedQuality = 2;

            Story.Given("Item is brie", () => this.PopulateItem(ItemTypes.Brie, item, quality, sellin))
                .When("Update Quality", () => this.RunProgram(item))
                .Then("Quality increases", () => this.QualityIs(item, expectedQuality))
                .Start();
        }

        [Fact]
        public void GIVEN_Item_Has_A_Quality_Of_Fifty_WHEN_UpdateQuality_THEN_Quality_Does_Not_Go_Above_Fifty()
        {
            var item = new Item();
            var quality = 50;
            var sellin = 1;
            var expectedQuality = 50;

            Story.Given("Item has quality of fifty", () => this.PopulateItem(ItemTypes.Brie, item, quality, sellin))
                .When("Update Quality", () => this.RunProgram(item))
                .Then("Quality remains at fifty", () => this.QualityIs(item, expectedQuality))
                .Start();
        }

        [Fact]
        public void GIVEN_Item_Is_Sulfuras_WHEN_UpdateQuality_THEN_SellIn_Stays_The_Same_AND_Quality_Stays_The_Same()
        {
            var item = new Item();
            var quality = 50;
            var sellin = 1;
            var expectedQuality = 50;
            var expectedSellin = 1;

            Story.Given("Item is Sulfuras", () => this.PopulateItem(ItemTypes.Sulfuras, item, quality, sellin))
                .When("Update Quality", () => this.RunProgram(item))
                .Then("Quality remains the same", () => this.QualityIs(item, expectedQuality))
                .And("SellIn remains the same", () => this.SellinIs(item, expectedSellin))
                .Start();
        }

        [Fact]
        public void GIVEN_Item_Is_Backstage_Passes_AND_SellIn_Is_Greater_Than_Ten_WHEN_UpdateQuality_THEN_Quality_Increases_By_One()
        {
            var item = new Item();
            var quality = 1;
            var sellin = 11;
            var expectedQuality = 2;

            Story.Given("Item is Backstage passes and Sellin is greater than ten", () => this.PopulateItem(ItemTypes.BackStagePasses, item, quality, sellin))
                .When("Update Quality", () => this.RunProgram(item))
                .Then("Quality increases by one", () => this.QualityIs(item, expectedQuality))
                .Start();
        }

        [Fact]
        public void GIVEN_Item_Is_Backstage_Passes_AND_SellIn_Is_Less_Than_Eleven_WHEN_UpdateQuality_THEN_Quality_Increases_By_Two()
        {
            var item = new Item();
            var quality = 1;
            var sellin = 10;
            var expectedQuality = 3;

            Story.Given("Item is Backstage passes and Sellin is less than eleven", () => this.PopulateItem(ItemTypes.BackStagePasses, item, quality, sellin))
                .When("Update Quality", () => this.RunProgram(item))
                .Then("Quality increases by two", () => this.QualityIs(item, expectedQuality))
                .Start();
        }

        [Fact]
        public void GIVEN_Item_Is_Backstage_Passes_AND_SellIn_Is_Less_Than_Six_WHEN_UpdateQuality_THEN_Quality_Increases_By_Three()
        {
            var item = new Item();
            var quality = 1;
            var sellin = 5;
            var expectedQuality = 4;

            Story.Given("Item is Backstage passes and Sellin is less than 6", () => this.PopulateItem(ItemTypes.BackStagePasses, item, quality, sellin))
                .When("Update Quality", () => this.RunProgram(item))
                .Then("Quality increases by three", () => this.QualityIs(item, expectedQuality))
                .Start();
        }

        [Fact]
        public void GIVEN_Item_Is_Backstage_Passes_AND_SellIn_Is_Zero_WHEN_UpdateQuality_THEN_Quality_Is_Zero()
        {
            var item = new Item();
            var quality = 1;
            var sellin = 0;
            var expectedQuality = 0;

            Story.Given("Item is Backstage passes and Sellin is zero", () => this.PopulateItem(ItemTypes.BackStagePasses, item, quality, sellin))
                .When("Update Quality", () => this.RunProgram(item))
                .Then("Quality is zero", () => this.QualityIs(item, expectedQuality))
                .Start();
        }

        [Fact]
        public void GIVEN_Item_Is_Dexterity_Vest_WHEN_UpdateQuality_THEN_Lowers_Quality_AND_Sellin()
        {
            var item = new Item();
            var quality = 2;
            var sellin = 2;
            var expectedQuality = 1;
            var expectedSellin = 1;

            Story.Given("Item is Dexterity Vest", () => this.PopulateItem(ItemTypes.DexterityVest, item, quality, sellin))
                .When("Update Quality", () => this.RunProgram(item))
                .Then("Quality is lowered", () => this.QualityIs(item, expectedQuality))
                .And("Sellin is lowered", () => this.SellinIs(item, expectedSellin))
                .Start();
        }

        [Fact]
        public void GIVEN_Item_Is_Elixir_Mongoose_WHEN_UpdateQuality_THEN_Lowers_Quality_AND_Sellin()
        {
            var item = new Item();
            var quality = 2;
            var sellin = 2;
            var expectedQuality = 1;
            var expectedSellin = 1;

            Story.Given("Item is Elixir Mongoose", () => this.PopulateItem(ItemTypes.ElixirMongoose, item, quality, sellin))
                .When("Update Quality", () => this.RunProgram(item))
                .Then("Quality is lowered", () => this.QualityIs(item, expectedQuality))
                .And("Sellin is lowered", () => this.SellinIs(item, expectedSellin))
                .Start();
        }

        [Fact]
        public void GIVEN_Item_Is_Conjured_Mana_Cake_WHEN_UpdateQuality_THEN_Lowers_Sellin_By_One_AND_Quality_By_Two()
        {
            var item = new Item();
            var quality = 2;
            var sellin = 2;
            var expectedQuality = 0;
            var expectedSellin = 1;

            Story.Given("Item is Conjured Mana Cake", () => this.PopulateItem(ItemTypes.ConjuredManaCake, item, quality, sellin))
                .When("Update Quality", () => this.RunProgram(item))
                .Then("Quality is lowered", () => this.QualityIs(item, expectedQuality))
                .And("Sellin is lowered", () => this.SellinIs(item, expectedSellin))
                .Start();
        }

        [Fact]
        public void GIVEN_Item_Is_Conjured_Mana_Cake_AND_Quality_Is_Zero_WHEN_UpdateQuality_THEN_Quality_Remains_At_Zero()
        {
            var item = new Item();
            var quality = 0;
            var sellin = 2;
            var expectedQuality = 0;

            Story.Given("Item is Conjured Mana Cake and Quality is Zero", () => this.PopulateItem(ItemTypes.ConjuredManaCake, item, quality, sellin))
                .When("Update Quality", () => this.RunProgram(item))
                .Then("Quality Remains at Zero", () => this.QualityIs(item, expectedQuality))
                .Start();
        }

        [Fact]
        public void GIVEN_Item_Is_Conjured_Mana_Cake_AND_Is_Passed_Sell_By_Date_WHEN_UpdateQuality_THEN_Quality_Degrades_Twice_As_Fast()
        {
            var item = new Item();
            var quality = 4;
            var sellin = -1;
            var expectedQuality = 0;

            Story.Given("Item is Conjured Mana Cake and is passed sell by date", () => this.PopulateItem(ItemTypes.ConjuredManaCake, item, quality, sellin))
                .When("Update Quality", () => this.RunProgram(item))
                .Then("Quality Degrades twice as fast", () => this.QualityIs(item, expectedQuality))
                .Start();
        }

        private void SellinIs(Item item, int expectedSellin)
        {
            Assert.Equal(expectedSellin, item.SellIn);
        }

        private void QualityIs(Item item, int expectedQuality)
        {
            Assert.Equal(expectedQuality, item.Quality);
        }

        private void RunProgram(Item item)
        {
            var program = new Program() { Items = new[] { item } };
            program.UpdateQuality();
        }

        private void PopulateItem(Item item, int quality, int sellin)
        {
            this.PopulateItem(ItemTypes.DexterityVest, item, quality, sellin);
        }

        private void PopulateItem(string name, Item item, int quality, int sellin)
        {
            item.Name = name;
            item.Quality = quality;
            item.SellIn = sellin;
        }
    }
}
using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class FinalGuncellemeler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "CaloriesPer100g", "CarbsPer100g", "CreatedBy", "CreatedDate", "FatPer100g", "Name", "ProteinPer100g", "SugarPer100g", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 165.0, 0.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4617), 3.6000000000000001, "Tavuk Göğsü", 31.0, 0.0, null, null },
                    { 2, 120.0, 0.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4635), 4.0, "Tavuk But", 19.0, 0.0, null, null },
                    { 3, 250.0, 0.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4636), 20.0, "Dana Kıyma", 17.0, 0.0, null, null },
                    { 4, 143.0, 0.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4638), 3.5, "Dana Kuşbaşı", 26.0, 0.0, null, null },
                    { 5, 114.0, 0.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4639), 1.5, "Hindi Göğsü", 23.699999999999999, 0.0, null, null },
                    { 6, 116.0, 0.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4640), 0.80000000000000004, "Ton Balığı (Konserve)", 25.5, 0.0, null, null },
                    { 7, 208.0, 0.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4641), 13.4, "Somon Balığı", 20.399999999999999, 0.0, null, null },
                    { 8, 143.0, 0.69999999999999996, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4642), 9.5, "Yumurta", 12.5, 0.29999999999999999, null, null },
                    { 9, 61.0, 4.7999999999999998, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4644), 3.2999999999999998, "Tam Yağlı Süt", 3.2000000000000002, 5.0999999999999996, null, null },
                    { 10, 47.0, 4.7999999999999998, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4645), 1.5, "Yarım Yağlı Süt", 3.2999999999999998, 5.0, null, null },
                    { 11, 61.0, 4.7000000000000002, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4646), 3.2999999999999998, "Yoğurt", 3.5, 4.7000000000000002, null, null },
                    { 12, 97.0, 4.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4647), 5.0, "Süzme Yoğurt", 9.0, 4.0, null, null },
                    { 13, 98.0, 3.3999999999999999, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4648), 4.2999999999999998, "Lor Peyniri", 11.1, 2.7000000000000002, null, null },
                    { 14, 264.0, 0.69999999999999996, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4649), 21.0, "Beyaz Peynir", 14.199999999999999, 0.5, null, null },
                    { 15, 402.0, 1.3, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4650), 33.100000000000001, "Kaşar Peyniri", 25.0, 0.5, null, null },
                    { 16, 389.0, 66.299999999999997, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4652), 6.9000000000000004, "Yulaf Ezmesi", 16.899999999999999, 0.0, null, null },
                    { 17, 365.0, 80.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4653), 0.69999999999999996, "Pirinç", 7.0999999999999996, 0.10000000000000001, null, null },
                    { 18, 342.0, 75.900000000000006, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4654), 1.3, "Bulgur", 12.300000000000001, 0.40000000000000002, null, null },
                    { 19, 371.0, 74.700000000000003, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4656), 1.5, "Makarna", 13.0, 2.7000000000000002, null, null },
                    { 20, 77.0, 17.5, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4657), 0.10000000000000001, "Patates", 2.0, 0.80000000000000004, null, null },
                    { 21, 86.0, 20.100000000000001, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4658), 0.10000000000000001, "Tatlı Patates", 1.6000000000000001, 4.2000000000000002, null, null },
                    { 22, 247.0, 41.299999999999997, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4659), 3.3999999999999999, "Tam Buğday Ekmeği", 13.0, 4.2999999999999998, null, null },
                    { 23, 266.0, 49.299999999999997, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4660), 3.2999999999999998, "Beyaz Ekmek", 8.9000000000000004, 5.0, null, null },
                    { 24, 295.0, 55.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4662), 3.5, "Lavaş / Dürüm", 9.0, 2.0, null, null },
                    { 25, 358.0, 63.100000000000001, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4663), 2.2000000000000002, "Kırmızı Mercimek", 23.899999999999999, 2.0, null, null },
                    { 26, 353.0, 60.100000000000001, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4664), 1.1000000000000001, "Yeşil Mercimek", 25.800000000000001, 2.0, null, null },
                    { 27, 364.0, 61.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4665), 6.0, "Nohut", 19.300000000000001, 10.699999999999999, null, null },
                    { 28, 333.0, 60.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4666), 0.80000000000000004, "Kuru Fasulye", 23.600000000000001, 2.1000000000000001, null, null },
                    { 29, 333.0, 60.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4667), 0.80000000000000004, "Barbunya", 23.600000000000001, 2.2000000000000002, null, null },
                    { 30, 884.0, 0.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4668), 100.0, "Zeytinyağı", 0.0, 0.0, null, null },
                    { 31, 717.0, 0.10000000000000001, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4669), 81.099999999999994, "Tereyağı", 0.90000000000000002, 0.10000000000000001, null, null },
                    { 32, 588.0, 20.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4670), 50.0, "Fıstık Ezmesi (Şekersiz)", 25.0, 9.1999999999999993, null, null },
                    { 33, 579.0, 21.600000000000001, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4671), 49.899999999999999, "Badem", 21.199999999999999, 4.4000000000000004, null, null },
                    { 34, 628.0, 16.699999999999999, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4672), 60.799999999999997, "Fındık", 15.0, 4.2999999999999998, null, null },
                    { 35, 654.0, 13.699999999999999, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4674), 65.200000000000003, "Ceviz", 15.199999999999999, 2.6000000000000001, null, null },
                    { 36, 585.0, 21.300000000000001, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4677), 49.700000000000003, "Kavrulmuş Yer Fıstığı", 23.699999999999999, 4.9000000000000004, null, null },
                    { 37, 115.0, 6.2999999999999998, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4678), 10.699999999999999, "Siyah Zeytin", 0.80000000000000004, 0.0, null, null },
                    { 38, 145.0, 3.7999999999999998, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4679), 15.300000000000001, "Yeşil Zeytin", 1.0, 0.5, null, null },
                    { 39, 304.0, 82.400000000000006, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4680), 0.0, "Bal", 0.29999999999999999, 82.099999999999994, null, null },
                    { 40, 18.0, 3.8999999999999999, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4681), 0.20000000000000001, "Domates", 0.90000000000000002, 2.6000000000000001, null, null },
                    { 41, 15.0, 3.6000000000000001, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4682), 0.10000000000000001, "Salatalık", 0.69999999999999996, 1.7, null, null },
                    { 42, 40.0, 9.3000000000000007, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4684), 0.10000000000000001, "Kuru Soğan", 1.1000000000000001, 4.2000000000000002, null, null },
                    { 43, 41.0, 9.5999999999999996, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4685), 0.20000000000000001, "Havuç", 0.90000000000000002, 4.7000000000000002, null, null },
                    { 44, 34.0, 6.5999999999999996, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4686), 0.40000000000000002, "Brokoli", 2.7999999999999998, 1.7, null, null },
                    { 45, 23.0, 3.6000000000000001, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4687), 0.40000000000000002, "Ispanak", 2.8999999999999999, 0.40000000000000002, null, null },
                    { 46, 89.0, 22.800000000000001, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4688), 0.29999999999999999, "Muz", 1.1000000000000001, 12.199999999999999, null, null },
                    { 47, 52.0, 13.800000000000001, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4689), 0.20000000000000001, "Elma", 0.29999999999999999, 10.4, null, null },
                    { 48, 47.0, 11.800000000000001, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4690), 0.10000000000000001, "Portakal", 0.90000000000000002, 9.4000000000000004, null, null },
                    { 49, 32.0, 7.7000000000000002, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4691), 0.29999999999999999, "Çilek", 0.69999999999999996, 4.9000000000000004, null, null },
                    { 50, 30.0, 7.5999999999999996, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4692), 0.20000000000000001, "Karpuz", 0.59999999999999998, 6.2000000000000002, null, null },
                    { 51, 250.0, 0.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4693), 14.0, "Pastırma (Çemensiz)", 30.0, 0.0, null, null },
                    { 52, 135.0, 4.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4695), 4.0, "Dana Ciğer", 20.0, 0.0, null, null },
                    { 53, 200.0, 0.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4696), 15.0, "Tavuk Kanat (Derili)", 18.0, 0.0, null, null },
                    { 54, 131.0, 0.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4698), 5.0, "Hamsi", 20.0, 0.0, null, null },
                    { 55, 97.0, 0.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4699), 2.0, "Levrek", 18.0, 0.0, null, null },
                    { 56, 43.0, 4.7999999999999998, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4700), 1.0, "Kefir", 3.2999999999999998, 4.7999999999999998, null, null },
                    { 57, 85.0, 2.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4723), 1.0, "Çökelek", 14.0, 1.5, null, null },
                    { 58, 250.0, 1.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4725), 18.0, "Dil Peyniri", 20.0, 1.0, null, null },
                    { 59, 320.0, 2.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4726), 25.0, "Hellim Peyniri", 22.0, 1.0, null, null },
                    { 60, 350.0, 2.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4727), 27.0, "Tulum Peyniri", 25.0, 1.0, null, null },
                    { 61, 275.0, 55.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4728), 2.0, "Simit", 9.0, 5.0, null, null },
                    { 62, 220.0, 40.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4729), 3.0, "Kepek Ekmeği", 9.0, 3.0, null, null },
                    { 63, 259.0, 48.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4730), 3.0, "Çavdar Ekmeği", 9.0, 3.0, null, null },
                    { 64, 400.0, 75.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4731), 5.0, "Galeta (Sade)", 11.0, 2.0, null, null },
                    { 65, 280.0, 55.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4732), 2.0, "Yufka", 8.0, 1.0, null, null },
                    { 66, 360.0, 73.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4734), 1.0, "İrmik", 10.0, 1.0, null, null },
                    { 67, 370.0, 75.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4735), 1.0, "Tel Şehriye", 12.0, 1.0, null, null },
                    { 68, 96.0, 21.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4736), 1.5, "Mısır (Taze/Süt)", 3.0, 4.5, null, null },
                    { 69, 130.0, 23.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4737), 0.5, "Barbunya (Taze)", 9.0, 2.0, null, null },
                    { 70, 33.0, 7.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4738), 0.20000000000000001, "Bamya (Çiğ)", 2.0, 1.5, null, null },
                    { 71, 31.0, 7.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4740), 0.20000000000000001, "Yeşil Fasulye (Çiğ)", 1.8, 3.0, null, null },
                    { 72, 81.0, 14.5, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4741), 0.40000000000000002, "Bezelye (Çiğ)", 5.4000000000000004, 5.7000000000000002, null, null },
                    { 73, 574.0, 15.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4742), 49.0, "Kabak Çekirdeği", 30.0, 1.3, null, null },
                    { 74, 560.0, 28.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4743), 45.0, "Antep Fıstığı", 20.0, 7.7000000000000002, null, null },
                    { 75, 380.0, 58.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4744), 5.0, "Sarı Leblebi", 19.0, 10.0, null, null },
                    { 76, 595.0, 21.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4745), 54.0, "Tahin", 17.0, 0.5, null, null },
                    { 77, 240.0, 63.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4746), 0.5, "Kuru Kayısı", 3.0, 53.0, null, null },
                    { 78, 250.0, 64.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4747), 1.0, "Kuru İncir", 3.0, 48.0, null, null },
                    { 79, 300.0, 79.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4749), 0.5, "Kuru Üzüm", 3.0, 59.0, null, null },
                    { 80, 280.0, 75.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4750), 0.40000000000000002, "Hurma (Medine)", 2.0, 63.0, null, null },
                    { 81, 26.0, 6.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4751), 0.29999999999999999, "Kapya Biber", 1.0, 4.2000000000000002, null, null },
                    { 82, 25.0, 6.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4752), 0.20000000000000001, "Patlıcan", 1.0, 3.5, null, null },
                    { 83, 17.0, 3.1000000000000001, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4755), 0.29999999999999999, "Yeşil Kabak", 1.2, 2.5, null, null },
                    { 84, 25.0, 5.7999999999999998, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4756), 0.10000000000000001, "Beyaz Lahana", 1.3, 3.2000000000000002, null, null },
                    { 85, 25.0, 5.0, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4757), 0.29999999999999999, "Karnabahar", 1.8999999999999999, 1.8999999999999999, null, null },
                    { 86, 22.0, 3.2999999999999998, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4758), 0.29999999999999999, "Kültür Mantarı", 3.1000000000000001, 2.0, null, null },
                    { 87, 61.0, 14.199999999999999, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4759), 0.29999999999999999, "Pırasa", 1.5, 3.8999999999999999, null, null },
                    { 88, 15.0, 2.8999999999999999, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4761), 0.20000000000000001, "Marul / Göbek", 1.3999999999999999, 0.80000000000000004, null, null },
                    { 89, 36.0, 6.2999999999999998, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4762), 0.80000000000000004, "Maydanoz", 3.0, 0.90000000000000002, null, null },
                    { 90, 29.0, 9.3000000000000007, null, new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4763), 0.29999999999999999, "Limon", 1.1000000000000001, 2.5, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Exercises");
        }
    }
}

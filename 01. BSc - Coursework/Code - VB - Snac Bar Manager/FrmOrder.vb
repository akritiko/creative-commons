Public Class frmOrder
    Inherits System.Windows.Forms.Form

    Private activeTable As Button
    Private tableNum As Integer
    Private orderOfTable(33) As TableOrder
    Private total As New PrecisionOfTwo(0.0)
    Private hasGivenOrder As Boolean
    Private cashRegisters As ArrayList
    Private managersCashRegister As Cash

#Region " Windows Form Designer generated code "

    Public Sub New(ByRef _cashRegs, ByRef _managersCashReg)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Dim k As Integer
        For k = 0 To 33
            orderOfTable(k) = New TableOrder
        Next
        cashRegisters = _cashRegs
        managersCashRegister = _managersCashReg
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents pnlCategories As System.Windows.Forms.Panel
    Friend WithEvents cmdAlcohol As System.Windows.Forms.Button
    Friend WithEvents cmdBeverages As System.Windows.Forms.Button
    Friend WithEvents cmdSnacks As System.Windows.Forms.Button
    Friend WithEvents cmdEnergyDrinks As System.Windows.Forms.Button
    Friend WithEvents cmdWine As System.Windows.Forms.Button
    Friend WithEvents cmdDrinks As System.Windows.Forms.Button
    Friend WithEvents cmdCoctails As System.Windows.Forms.Button
    Friend WithEvents cmdBeers As System.Windows.Forms.Button
    Friend WithEvents pnlAlcohol As System.Windows.Forms.Panel
    Friend WithEvents cmdMilkShake As System.Windows.Forms.Button
    Friend WithEvents cmdChoco As System.Windows.Forms.Button
    Friend WithEvents cmdTea As System.Windows.Forms.Button
    Friend WithEvents cmdJuices As System.Windows.Forms.Button
    Friend WithEvents cmdCoffees As System.Windows.Forms.Button
    Friend WithEvents pnlBeverages As System.Windows.Forms.Panel
    Friend WithEvents cmdDesserts As System.Windows.Forms.Button
    Friend WithEvents cmdHotDishes As System.Windows.Forms.Button
    Friend WithEvents cmdToast As System.Windows.Forms.Button
    Friend WithEvents cmdBurgers As System.Windows.Forms.Button
    Friend WithEvents cmdColdDishes As System.Windows.Forms.Button
    Friend WithEvents pnlSnacks As System.Windows.Forms.Panel
    Friend WithEvents pnlSoftdrinks As System.Windows.Forms.Panel
    Friend WithEvents cmdWater As System.Windows.Forms.Button
    Friend WithEvents cmdSoda As System.Windows.Forms.Button
    Friend WithEvents cmdBottles As System.Windows.Forms.Button
    Friend WithEvents cmdCans As System.Windows.Forms.Button
    Friend WithEvents cmdSend As System.Windows.Forms.Button
    Friend WithEvents cmdPrintCheck As System.Windows.Forms.Button
    Friend WithEvents cmdSubQuantity As System.Windows.Forms.Button
    Friend WithEvents item As System.Windows.Forms.ColumnHeader
    Friend WithEvents quantity As System.Windows.Forms.ColumnHeader
    Friend WithEvents price As System.Windows.Forms.ColumnHeader
    Friend WithEvents lsvCurrent As System.Windows.Forms.ListView
    Friend WithEvents pnlBeers As System.Windows.Forms.Panel
    Friend WithEvents pnlDrinks As System.Windows.Forms.Panel
    Friend WithEvents pnlCocktails As System.Windows.Forms.Panel
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblEuroSign As System.Windows.Forms.Label
    Friend WithEvents lblSum As System.Windows.Forms.Label
    Friend WithEvents cmdBudweiser As System.Windows.Forms.Button
    Friend WithEvents cmdAmstel As System.Windows.Forms.Button
    Friend WithEvents cmdCoronaExtra As System.Windows.Forms.Button
    Friend WithEvents cmdHeineken As System.Windows.Forms.Button
    Friend WithEvents cmdBudLight As System.Windows.Forms.Button
    Friend WithEvents cmdBud As System.Windows.Forms.Button
    Friend WithEvents cmdMillerLite As System.Windows.Forms.Button
    Friend WithEvents cmdGoorsLight As System.Windows.Forms.Button
    Friend WithEvents cmdBacardiBreezer As System.Windows.Forms.Button
    Friend WithEvents cmdSmirnoffIce As System.Windows.Forms.Button
    Friend WithEvents cmdGordonsSpace As System.Windows.Forms.Button
    Friend WithEvents cmdMargarita As System.Windows.Forms.Button
    Friend WithEvents cmdWhiteRussian As System.Windows.Forms.Button
    Friend WithEvents cmdB52 As System.Windows.Forms.Button
    Friend WithEvents cmdTequillaSunrise As System.Windows.Forms.Button
    Friend WithEvents cmdCardu As System.Windows.Forms.Button
    Friend WithEvents cmdJimBeam As System.Windows.Forms.Button
    Friend WithEvents cmdChivasRegal As System.Windows.Forms.Button
    Friend WithEvents cmdSmirnoffVodka As System.Windows.Forms.Button
    Friend WithEvents cmdAbsolutVodka As System.Windows.Forms.Button
    Friend WithEvents cmdGlenfiddich As System.Windows.Forms.Button
    Friend WithEvents pnlAlcoholSoftDrinks As System.Windows.Forms.Panel
    Friend WithEvents pnlWines As System.Windows.Forms.Panel
    Friend WithEvents pnlCoffees As System.Windows.Forms.Panel
    Friend WithEvents pnlColdDishes As System.Windows.Forms.Panel
    Friend WithEvents pnlJuices As System.Windows.Forms.Panel
    Friend WithEvents pnlTea As System.Windows.Forms.Panel
    Friend WithEvents pnlChoco As System.Windows.Forms.Panel
    Friend WithEvents pnlMilkShake As System.Windows.Forms.Panel
    Friend WithEvents pnlWater As System.Windows.Forms.Panel
    Friend WithEvents pnlSoda As System.Windows.Forms.Panel
    Friend WithEvents pnlBottles As System.Windows.Forms.Panel
    Friend WithEvents pnlCans As System.Windows.Forms.Panel
    Friend WithEvents pnlHotDishes As System.Windows.Forms.Panel
    Friend WithEvents pnlBurgers As System.Windows.Forms.Panel
    Friend WithEvents pnlToast As System.Windows.Forms.Panel
    Friend WithEvents pnlDesserts As System.Windows.Forms.Panel
    Friend WithEvents cmdSoftdrinks As System.Windows.Forms.Button
    Friend WithEvents cmdAlcSoftdrinks As System.Windows.Forms.Button
    Friend WithEvents pnlEnergyDrinks As System.Windows.Forms.Panel
    Friend WithEvents cmdBackToMainMenu As System.Windows.Forms.Button
    Friend WithEvents cmdCategoryBack As System.Windows.Forms.Button
    Friend WithEvents pnlNoItems As System.Windows.Forms.Panel
    Friend WithEvents cmdBoutariWhite As System.Windows.Forms.Button
    Friend WithEvents cmdBoutariRed As System.Windows.Forms.Button
    Friend WithEvents cmdToastCheese As System.Windows.Forms.Button
    Friend WithEvents cmdToastHamCheese As System.Windows.Forms.Button
    Friend WithEvents cmdCake As System.Windows.Forms.Button
    Friend WithEvents cmdApplepie As System.Windows.Forms.Button
    Friend WithEvents cmdTsantaliWhite As System.Windows.Forms.Button
    Friend WithEvents cmdTsantaliRed As System.Windows.Forms.Button
    Friend WithEvents cmdBlackForrest As System.Windows.Forms.Button
    Friend WithEvents cmdCheeseCake As System.Windows.Forms.Button
    Friend WithEvents cmdCroissant As System.Windows.Forms.Button
    Friend WithEvents cmdIcecream As System.Windows.Forms.Button
    Friend WithEvents cmdDoughnut As System.Windows.Forms.Button
    Friend WithEvents cmdToastChips As System.Windows.Forms.Button
    Friend WithEvents cmdToastChipsBrown As System.Windows.Forms.Button
    Friend WithEvents cmdToastCheeseBrown As System.Windows.Forms.Button
    Friend WithEvents cmdToastHamCheeseBrown As System.Windows.Forms.Button
    Friend WithEvents cmdEggs As System.Windows.Forms.Button
    Friend WithEvents cmdOvenPotato As System.Windows.Forms.Button
    Friend WithEvents cmdHotDog As System.Windows.Forms.Button
    Friend WithEvents cmdDoubleBurger As System.Windows.Forms.Button
    Friend WithEvents cmdFrenchFries As System.Windows.Forms.Button
    Friend WithEvents cmdBurgerGalore As System.Windows.Forms.Button
    Friend WithEvents cmdCheeseBurger As System.Windows.Forms.Button
    Friend WithEvents cmdHumBurger As System.Windows.Forms.Button
    Friend WithEvents cmdPizza As System.Windows.Forms.Button
    Friend WithEvents cmdCarlsberg As System.Windows.Forms.Button
    Friend WithEvents cmdGordons As System.Windows.Forms.Button
    Friend WithEvents cmd7up As System.Windows.Forms.Button
    Friend WithEvents cmdPepsi As System.Windows.Forms.Button
    Friend WithEvents cmdCocaCola As System.Windows.Forms.Button
    Friend WithEvents cmdJohnnieWalker As System.Windows.Forms.Button
    Friend WithEvents cmdJackDaniels As System.Windows.Forms.Button
    Friend WithEvents cmdFanta As System.Windows.Forms.Button
    Friend WithEvents cmdVariousCocktails As System.Windows.Forms.Button
    Friend WithEvents cmdSteak As System.Windows.Forms.Button
    Friend WithEvents cmdSteak2 As System.Windows.Forms.Button
    Friend WithEvents cmdIceCreamSpecial As System.Windows.Forms.Button
    Friend WithEvents cmdSprite As System.Windows.Forms.Button
    Friend WithEvents cmdFrappe As System.Windows.Forms.Button
    Friend WithEvents cmdNes As System.Windows.Forms.Button
    Friend WithEvents cmdSandwich As System.Windows.Forms.Button
    Friend WithEvents cmdSalads As System.Windows.Forms.Button
    Friend WithEvents cmdPeach As System.Windows.Forms.Button
    Friend WithEvents cmdOrange As System.Windows.Forms.Button
    Friend WithEvents cmdLipton As System.Windows.Forms.Button
    Friend WithEvents cmdColdChoco As System.Windows.Forms.Button
    Friend WithEvents cmdHotChoco As System.Windows.Forms.Button
    Friend WithEvents cmdMShake As System.Windows.Forms.Button
    Friend WithEvents cmdWater500 As System.Windows.Forms.Button
    Friend WithEvents cmdYdor As System.Windows.Forms.Button
    Friend WithEvents cmdSourotiOrange As System.Windows.Forms.Button
    Friend WithEvents cmdLucosade As System.Windows.Forms.Button
    Friend WithEvents cmdRedBull As System.Windows.Forms.Button
    Friend WithEvents cmdBanana As System.Windows.Forms.Button
    Friend WithEvents cmdCherry As System.Windows.Forms.Button
    Friend WithEvents cmdApricot As System.Windows.Forms.Button
    Friend WithEvents cmdMixed As System.Windows.Forms.Button
    Friend WithEvents cmdHotTea As System.Windows.Forms.Button
    Friend WithEvents cmdDrPepper As System.Windows.Forms.Button
    Friend WithEvents cmdDrPepperBottle As System.Windows.Forms.Button
    Friend WithEvents cmdSpriteBottle As System.Windows.Forms.Button
    Friend WithEvents cmdFantaBottle As System.Windows.Forms.Button
    Friend WithEvents cmd7upbottle As System.Windows.Forms.Button
    Friend WithEvents cmdPepsiBottle As System.Windows.Forms.Button
    Friend WithEvents cmdCocaBottle As System.Windows.Forms.Button
    Friend WithEvents cmdSouroti As System.Windows.Forms.Button
    Friend WithEvents cmdTuborg As System.Windows.Forms.Button
    Friend WithEvents cmdWater1000 As System.Windows.Forms.Button
    Friend WithEvents cmdIceTea As System.Windows.Forms.Button
    Friend WithEvents cmdSelfServe As System.Windows.Forms.Button
    Friend WithEvents hasAlchhol As System.Windows.Forms.ColumnHeader
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmOrder))
        Me.pnlNoItems = New System.Windows.Forms.Panel
        Me.pnlCategories = New System.Windows.Forms.Panel
        Me.cmdSoftdrinks = New System.Windows.Forms.Button
        Me.cmdEnergyDrinks = New System.Windows.Forms.Button
        Me.cmdSnacks = New System.Windows.Forms.Button
        Me.cmdBeverages = New System.Windows.Forms.Button
        Me.cmdAlcohol = New System.Windows.Forms.Button
        Me.pnlAlcohol = New System.Windows.Forms.Panel
        Me.cmdAlcSoftdrinks = New System.Windows.Forms.Button
        Me.cmdWine = New System.Windows.Forms.Button
        Me.cmdDrinks = New System.Windows.Forms.Button
        Me.cmdCoctails = New System.Windows.Forms.Button
        Me.cmdBeers = New System.Windows.Forms.Button
        Me.pnlBeverages = New System.Windows.Forms.Panel
        Me.cmdMilkShake = New System.Windows.Forms.Button
        Me.cmdChoco = New System.Windows.Forms.Button
        Me.cmdTea = New System.Windows.Forms.Button
        Me.cmdJuices = New System.Windows.Forms.Button
        Me.cmdCoffees = New System.Windows.Forms.Button
        Me.pnlSnacks = New System.Windows.Forms.Panel
        Me.cmdDesserts = New System.Windows.Forms.Button
        Me.cmdHotDishes = New System.Windows.Forms.Button
        Me.cmdBurgers = New System.Windows.Forms.Button
        Me.cmdColdDishes = New System.Windows.Forms.Button
        Me.cmdToast = New System.Windows.Forms.Button
        Me.pnlSoftdrinks = New System.Windows.Forms.Panel
        Me.cmdWater = New System.Windows.Forms.Button
        Me.cmdSoda = New System.Windows.Forms.Button
        Me.cmdBottles = New System.Windows.Forms.Button
        Me.cmdCans = New System.Windows.Forms.Button
        Me.cmdBackToMainMenu = New System.Windows.Forms.Button
        Me.cmdSend = New System.Windows.Forms.Button
        Me.cmdPrintCheck = New System.Windows.Forms.Button
        Me.cmdSubQuantity = New System.Windows.Forms.Button
        Me.cmdSelfServe = New System.Windows.Forms.Button
        Me.cmdCategoryBack = New System.Windows.Forms.Button
        Me.lsvCurrent = New System.Windows.Forms.ListView
        Me.item = New System.Windows.Forms.ColumnHeader
        Me.quantity = New System.Windows.Forms.ColumnHeader
        Me.price = New System.Windows.Forms.ColumnHeader
        Me.hasAlchhol = New System.Windows.Forms.ColumnHeader
        Me.pnlBeers = New System.Windows.Forms.Panel
        Me.cmdAmstel = New System.Windows.Forms.Button
        Me.cmdCoronaExtra = New System.Windows.Forms.Button
        Me.cmdMillerLite = New System.Windows.Forms.Button
        Me.cmdHeineken = New System.Windows.Forms.Button
        Me.cmdCarlsberg = New System.Windows.Forms.Button
        Me.cmdGoorsLight = New System.Windows.Forms.Button
        Me.cmdBudLight = New System.Windows.Forms.Button
        Me.cmdBud = New System.Windows.Forms.Button
        Me.cmdBudweiser = New System.Windows.Forms.Button
        Me.pnlDrinks = New System.Windows.Forms.Panel
        Me.cmdJackDaniels = New System.Windows.Forms.Button
        Me.cmdJohnnieWalker = New System.Windows.Forms.Button
        Me.cmdGordons = New System.Windows.Forms.Button
        Me.cmdCardu = New System.Windows.Forms.Button
        Me.cmdGlenfiddich = New System.Windows.Forms.Button
        Me.cmdJimBeam = New System.Windows.Forms.Button
        Me.cmdChivasRegal = New System.Windows.Forms.Button
        Me.cmdSmirnoffVodka = New System.Windows.Forms.Button
        Me.cmdAbsolutVodka = New System.Windows.Forms.Button
        Me.pnlCocktails = New System.Windows.Forms.Panel
        Me.cmdVariousCocktails = New System.Windows.Forms.Button
        Me.cmdMargarita = New System.Windows.Forms.Button
        Me.cmdWhiteRussian = New System.Windows.Forms.Button
        Me.cmdB52 = New System.Windows.Forms.Button
        Me.cmdTequillaSunrise = New System.Windows.Forms.Button
        Me.pnlAlcoholSoftDrinks = New System.Windows.Forms.Panel
        Me.cmdBacardiBreezer = New System.Windows.Forms.Button
        Me.cmdGordonsSpace = New System.Windows.Forms.Button
        Me.cmdSmirnoffIce = New System.Windows.Forms.Button
        Me.lblTotal = New System.Windows.Forms.Label
        Me.lblEuroSign = New System.Windows.Forms.Label
        Me.lblSum = New System.Windows.Forms.Label
        Me.pnlWines = New System.Windows.Forms.Panel
        Me.cmdTsantaliRed = New System.Windows.Forms.Button
        Me.cmdTsantaliWhite = New System.Windows.Forms.Button
        Me.cmdBoutariWhite = New System.Windows.Forms.Button
        Me.cmdBoutariRed = New System.Windows.Forms.Button
        Me.pnlCoffees = New System.Windows.Forms.Panel
        Me.cmdFrappe = New System.Windows.Forms.Button
        Me.cmdNes = New System.Windows.Forms.Button
        Me.pnlColdDishes = New System.Windows.Forms.Panel
        Me.cmdSandwich = New System.Windows.Forms.Button
        Me.cmdSalads = New System.Windows.Forms.Button
        Me.pnlJuices = New System.Windows.Forms.Panel
        Me.cmdMixed = New System.Windows.Forms.Button
        Me.cmdApricot = New System.Windows.Forms.Button
        Me.cmdCherry = New System.Windows.Forms.Button
        Me.cmdBanana = New System.Windows.Forms.Button
        Me.cmdPeach = New System.Windows.Forms.Button
        Me.cmdOrange = New System.Windows.Forms.Button
        Me.pnlTea = New System.Windows.Forms.Panel
        Me.cmdHotTea = New System.Windows.Forms.Button
        Me.cmdLipton = New System.Windows.Forms.Button
        Me.cmdIceTea = New System.Windows.Forms.Button
        Me.pnlChoco = New System.Windows.Forms.Panel
        Me.cmdColdChoco = New System.Windows.Forms.Button
        Me.cmdHotChoco = New System.Windows.Forms.Button
        Me.pnlMilkShake = New System.Windows.Forms.Panel
        Me.cmdMShake = New System.Windows.Forms.Button
        Me.pnlWater = New System.Windows.Forms.Panel
        Me.cmdWater1000 = New System.Windows.Forms.Button
        Me.cmdWater500 = New System.Windows.Forms.Button
        Me.cmdYdor = New System.Windows.Forms.Button
        Me.pnlSoda = New System.Windows.Forms.Panel
        Me.cmdTuborg = New System.Windows.Forms.Button
        Me.cmdSouroti = New System.Windows.Forms.Button
        Me.cmdSourotiOrange = New System.Windows.Forms.Button
        Me.pnlBottles = New System.Windows.Forms.Panel
        Me.cmdDrPepperBottle = New System.Windows.Forms.Button
        Me.cmdSpriteBottle = New System.Windows.Forms.Button
        Me.cmdFantaBottle = New System.Windows.Forms.Button
        Me.cmd7upbottle = New System.Windows.Forms.Button
        Me.cmdPepsiBottle = New System.Windows.Forms.Button
        Me.cmdCocaBottle = New System.Windows.Forms.Button
        Me.pnlCans = New System.Windows.Forms.Panel
        Me.cmdDrPepper = New System.Windows.Forms.Button
        Me.cmdSprite = New System.Windows.Forms.Button
        Me.cmdFanta = New System.Windows.Forms.Button
        Me.cmd7up = New System.Windows.Forms.Button
        Me.cmdPepsi = New System.Windows.Forms.Button
        Me.cmdCocaCola = New System.Windows.Forms.Button
        Me.pnlHotDishes = New System.Windows.Forms.Panel
        Me.cmdSteak2 = New System.Windows.Forms.Button
        Me.cmdSteak = New System.Windows.Forms.Button
        Me.cmdPizza = New System.Windows.Forms.Button
        Me.cmdFrenchFries = New System.Windows.Forms.Button
        Me.cmdEggs = New System.Windows.Forms.Button
        Me.cmdOvenPotato = New System.Windows.Forms.Button
        Me.pnlBurgers = New System.Windows.Forms.Panel
        Me.cmdHumBurger = New System.Windows.Forms.Button
        Me.cmdCheeseBurger = New System.Windows.Forms.Button
        Me.cmdBurgerGalore = New System.Windows.Forms.Button
        Me.cmdHotDog = New System.Windows.Forms.Button
        Me.cmdDoubleBurger = New System.Windows.Forms.Button
        Me.pnlToast = New System.Windows.Forms.Panel
        Me.cmdToastChipsBrown = New System.Windows.Forms.Button
        Me.cmdToastCheeseBrown = New System.Windows.Forms.Button
        Me.cmdToastHamCheeseBrown = New System.Windows.Forms.Button
        Me.cmdToastChips = New System.Windows.Forms.Button
        Me.cmdToastCheese = New System.Windows.Forms.Button
        Me.cmdToastHamCheese = New System.Windows.Forms.Button
        Me.pnlDesserts = New System.Windows.Forms.Panel
        Me.cmdIceCreamSpecial = New System.Windows.Forms.Button
        Me.cmdDoughnut = New System.Windows.Forms.Button
        Me.cmdIcecream = New System.Windows.Forms.Button
        Me.cmdCroissant = New System.Windows.Forms.Button
        Me.cmdCheeseCake = New System.Windows.Forms.Button
        Me.cmdBlackForrest = New System.Windows.Forms.Button
        Me.cmdCake = New System.Windows.Forms.Button
        Me.cmdApplepie = New System.Windows.Forms.Button
        Me.pnlEnergyDrinks = New System.Windows.Forms.Panel
        Me.cmdLucosade = New System.Windows.Forms.Button
        Me.cmdRedBull = New System.Windows.Forms.Button
        Me.pnlCategories.SuspendLayout()
        Me.pnlAlcohol.SuspendLayout()
        Me.pnlBeverages.SuspendLayout()
        Me.pnlSnacks.SuspendLayout()
        Me.pnlSoftdrinks.SuspendLayout()
        Me.pnlBeers.SuspendLayout()
        Me.pnlDrinks.SuspendLayout()
        Me.pnlCocktails.SuspendLayout()
        Me.pnlAlcoholSoftDrinks.SuspendLayout()
        Me.pnlWines.SuspendLayout()
        Me.pnlCoffees.SuspendLayout()
        Me.pnlColdDishes.SuspendLayout()
        Me.pnlJuices.SuspendLayout()
        Me.pnlTea.SuspendLayout()
        Me.pnlChoco.SuspendLayout()
        Me.pnlMilkShake.SuspendLayout()
        Me.pnlWater.SuspendLayout()
        Me.pnlSoda.SuspendLayout()
        Me.pnlBottles.SuspendLayout()
        Me.pnlCans.SuspendLayout()
        Me.pnlHotDishes.SuspendLayout()
        Me.pnlBurgers.SuspendLayout()
        Me.pnlToast.SuspendLayout()
        Me.pnlDesserts.SuspendLayout()
        Me.pnlEnergyDrinks.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlNoItems
        '
        Me.pnlNoItems.BackColor = System.Drawing.Color.DarkGray
        Me.pnlNoItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlNoItems.Location = New System.Drawing.Point(519, 39)
        Me.pnlNoItems.Name = "pnlNoItems"
        Me.pnlNoItems.Size = New System.Drawing.Size(345, 530)
        Me.pnlNoItems.TabIndex = 0
        '
        'pnlCategories
        '
        Me.pnlCategories.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlCategories.Controls.Add(Me.cmdSoftdrinks)
        Me.pnlCategories.Controls.Add(Me.cmdEnergyDrinks)
        Me.pnlCategories.Controls.Add(Me.cmdSnacks)
        Me.pnlCategories.Controls.Add(Me.cmdBeverages)
        Me.pnlCategories.Controls.Add(Me.cmdAlcohol)
        Me.pnlCategories.Location = New System.Drawing.Point(880, 40)
        Me.pnlCategories.Name = "pnlCategories"
        Me.pnlCategories.Size = New System.Drawing.Size(128, 416)
        Me.pnlCategories.TabIndex = 1
        '
        'cmdSoftdrinks
        '
        Me.cmdSoftdrinks.BackColor = System.Drawing.Color.MediumVioletRed
        Me.cmdSoftdrinks.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdSoftdrinks.ForeColor = System.Drawing.Color.White
        Me.cmdSoftdrinks.Location = New System.Drawing.Point(8, 280)
        Me.cmdSoftdrinks.Name = "cmdSoftdrinks"
        Me.cmdSoftdrinks.Size = New System.Drawing.Size(112, 56)
        Me.cmdSoftdrinks.TabIndex = 6
        Me.cmdSoftdrinks.Text = "ΑΝΑΨΥΚΤΙΚΑ"
        '
        'cmdEnergyDrinks
        '
        Me.cmdEnergyDrinks.BackColor = System.Drawing.Color.Tan
        Me.cmdEnergyDrinks.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdEnergyDrinks.ForeColor = System.Drawing.Color.White
        Me.cmdEnergyDrinks.Location = New System.Drawing.Point(8, 212)
        Me.cmdEnergyDrinks.Name = "cmdEnergyDrinks"
        Me.cmdEnergyDrinks.Size = New System.Drawing.Size(112, 56)
        Me.cmdEnergyDrinks.TabIndex = 5
        Me.cmdEnergyDrinks.Text = "ΙΣΟΤΟΝΙΚΑ"
        '
        'cmdSnacks
        '
        Me.cmdSnacks.BackColor = System.Drawing.Color.Salmon
        Me.cmdSnacks.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdSnacks.ForeColor = System.Drawing.Color.White
        Me.cmdSnacks.Location = New System.Drawing.Point(8, 144)
        Me.cmdSnacks.Name = "cmdSnacks"
        Me.cmdSnacks.Size = New System.Drawing.Size(112, 56)
        Me.cmdSnacks.TabIndex = 4
        Me.cmdSnacks.Text = "ΣΝΑΚΣ"
        '
        'cmdBeverages
        '
        Me.cmdBeverages.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.cmdBeverages.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdBeverages.ForeColor = System.Drawing.Color.White
        Me.cmdBeverages.Location = New System.Drawing.Point(8, 76)
        Me.cmdBeverages.Name = "cmdBeverages"
        Me.cmdBeverages.Size = New System.Drawing.Size(112, 56)
        Me.cmdBeverages.TabIndex = 3
        Me.cmdBeverages.Text = "ΑΦΕΨΗΜΑΤΑ"
        '
        'cmdAlcohol
        '
        Me.cmdAlcohol.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmdAlcohol.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdAlcohol.ForeColor = System.Drawing.Color.White
        Me.cmdAlcohol.Location = New System.Drawing.Point(8, 8)
        Me.cmdAlcohol.Name = "cmdAlcohol"
        Me.cmdAlcohol.Size = New System.Drawing.Size(112, 56)
        Me.cmdAlcohol.TabIndex = 2
        Me.cmdAlcohol.Text = "ΑΛΚΟΟΛΟΥΧΑ"
        '
        'pnlAlcohol
        '
        Me.pnlAlcohol.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlAlcohol.Controls.Add(Me.cmdAlcSoftdrinks)
        Me.pnlAlcohol.Controls.Add(Me.cmdWine)
        Me.pnlAlcohol.Controls.Add(Me.cmdDrinks)
        Me.pnlAlcohol.Controls.Add(Me.cmdCoctails)
        Me.pnlAlcohol.Controls.Add(Me.cmdBeers)
        Me.pnlAlcohol.Location = New System.Drawing.Point(880, 40)
        Me.pnlAlcohol.Name = "pnlAlcohol"
        Me.pnlAlcohol.Size = New System.Drawing.Size(128, 416)
        Me.pnlAlcohol.TabIndex = 2
        Me.pnlAlcohol.Visible = False
        '
        'cmdAlcSoftdrinks
        '
        Me.cmdAlcSoftdrinks.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmdAlcSoftdrinks.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdAlcSoftdrinks.ForeColor = System.Drawing.Color.White
        Me.cmdAlcSoftdrinks.Location = New System.Drawing.Point(8, 280)
        Me.cmdAlcSoftdrinks.Name = "cmdAlcSoftdrinks"
        Me.cmdAlcSoftdrinks.Size = New System.Drawing.Size(112, 56)
        Me.cmdAlcSoftdrinks.TabIndex = 6
        Me.cmdAlcSoftdrinks.Text = "ΑΛΚΟΟΛΟΥΧΑ ΑΝΑΨΥΚΤΙΚΑ"
        '
        'cmdWine
        '
        Me.cmdWine.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmdWine.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdWine.ForeColor = System.Drawing.Color.White
        Me.cmdWine.Location = New System.Drawing.Point(8, 212)
        Me.cmdWine.Name = "cmdWine"
        Me.cmdWine.Size = New System.Drawing.Size(112, 56)
        Me.cmdWine.TabIndex = 5
        Me.cmdWine.Text = "ΚΡΑΣΙΑ"
        '
        'cmdDrinks
        '
        Me.cmdDrinks.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmdDrinks.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdDrinks.ForeColor = System.Drawing.Color.White
        Me.cmdDrinks.Location = New System.Drawing.Point(8, 144)
        Me.cmdDrinks.Name = "cmdDrinks"
        Me.cmdDrinks.Size = New System.Drawing.Size(112, 56)
        Me.cmdDrinks.TabIndex = 4
        Me.cmdDrinks.Text = "ΠΟΤΑ"
        '
        'cmdCoctails
        '
        Me.cmdCoctails.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmdCoctails.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCoctails.ForeColor = System.Drawing.Color.White
        Me.cmdCoctails.Location = New System.Drawing.Point(8, 76)
        Me.cmdCoctails.Name = "cmdCoctails"
        Me.cmdCoctails.Size = New System.Drawing.Size(112, 56)
        Me.cmdCoctails.TabIndex = 3
        Me.cmdCoctails.Text = "ΚΟΚΤΕΪΛΣ"
        '
        'cmdBeers
        '
        Me.cmdBeers.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmdBeers.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdBeers.ForeColor = System.Drawing.Color.White
        Me.cmdBeers.Location = New System.Drawing.Point(8, 8)
        Me.cmdBeers.Name = "cmdBeers"
        Me.cmdBeers.Size = New System.Drawing.Size(112, 56)
        Me.cmdBeers.TabIndex = 2
        Me.cmdBeers.Text = "ΜΠΥΡΕΣ"
        '
        'pnlBeverages
        '
        Me.pnlBeverages.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlBeverages.Controls.Add(Me.cmdMilkShake)
        Me.pnlBeverages.Controls.Add(Me.cmdChoco)
        Me.pnlBeverages.Controls.Add(Me.cmdTea)
        Me.pnlBeverages.Controls.Add(Me.cmdJuices)
        Me.pnlBeverages.Controls.Add(Me.cmdCoffees)
        Me.pnlBeverages.Location = New System.Drawing.Point(880, 40)
        Me.pnlBeverages.Name = "pnlBeverages"
        Me.pnlBeverages.Size = New System.Drawing.Size(128, 416)
        Me.pnlBeverages.TabIndex = 4
        Me.pnlBeverages.Visible = False
        '
        'cmdMilkShake
        '
        Me.cmdMilkShake.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.cmdMilkShake.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdMilkShake.ForeColor = System.Drawing.Color.White
        Me.cmdMilkShake.Location = New System.Drawing.Point(8, 280)
        Me.cmdMilkShake.Name = "cmdMilkShake"
        Me.cmdMilkShake.Size = New System.Drawing.Size(112, 56)
        Me.cmdMilkShake.TabIndex = 6
        Me.cmdMilkShake.Text = "ΜΙΛΚ ΣΕΪΚ"
        '
        'cmdChoco
        '
        Me.cmdChoco.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.cmdChoco.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdChoco.ForeColor = System.Drawing.Color.White
        Me.cmdChoco.Location = New System.Drawing.Point(8, 212)
        Me.cmdChoco.Name = "cmdChoco"
        Me.cmdChoco.Size = New System.Drawing.Size(112, 56)
        Me.cmdChoco.TabIndex = 5
        Me.cmdChoco.Text = "ΣΟΚΟΛΑΤΕΣ"
        '
        'cmdTea
        '
        Me.cmdTea.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.cmdTea.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTea.ForeColor = System.Drawing.Color.White
        Me.cmdTea.Location = New System.Drawing.Point(8, 144)
        Me.cmdTea.Name = "cmdTea"
        Me.cmdTea.Size = New System.Drawing.Size(112, 56)
        Me.cmdTea.TabIndex = 4
        Me.cmdTea.Text = "ΤΣΑΪ"
        '
        'cmdJuices
        '
        Me.cmdJuices.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.cmdJuices.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdJuices.ForeColor = System.Drawing.Color.White
        Me.cmdJuices.Location = New System.Drawing.Point(8, 76)
        Me.cmdJuices.Name = "cmdJuices"
        Me.cmdJuices.Size = New System.Drawing.Size(112, 56)
        Me.cmdJuices.TabIndex = 3
        Me.cmdJuices.Text = "ΧΥΜΟΙ"
        '
        'cmdCoffees
        '
        Me.cmdCoffees.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.cmdCoffees.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCoffees.ForeColor = System.Drawing.Color.White
        Me.cmdCoffees.Location = New System.Drawing.Point(8, 8)
        Me.cmdCoffees.Name = "cmdCoffees"
        Me.cmdCoffees.Size = New System.Drawing.Size(112, 56)
        Me.cmdCoffees.TabIndex = 2
        Me.cmdCoffees.Text = "ΚΑΦΕΔΕΣ"
        '
        'pnlSnacks
        '
        Me.pnlSnacks.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlSnacks.Controls.Add(Me.cmdDesserts)
        Me.pnlSnacks.Controls.Add(Me.cmdHotDishes)
        Me.pnlSnacks.Controls.Add(Me.cmdBurgers)
        Me.pnlSnacks.Controls.Add(Me.cmdColdDishes)
        Me.pnlSnacks.Controls.Add(Me.cmdToast)
        Me.pnlSnacks.Location = New System.Drawing.Point(880, 40)
        Me.pnlSnacks.Name = "pnlSnacks"
        Me.pnlSnacks.Size = New System.Drawing.Size(128, 416)
        Me.pnlSnacks.TabIndex = 5
        Me.pnlSnacks.Visible = False
        '
        'cmdDesserts
        '
        Me.cmdDesserts.BackColor = System.Drawing.Color.Salmon
        Me.cmdDesserts.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdDesserts.ForeColor = System.Drawing.Color.White
        Me.cmdDesserts.Location = New System.Drawing.Point(8, 280)
        Me.cmdDesserts.Name = "cmdDesserts"
        Me.cmdDesserts.Size = New System.Drawing.Size(112, 56)
        Me.cmdDesserts.TabIndex = 6
        Me.cmdDesserts.Text = "ΓΛΥΚΑ"
        '
        'cmdHotDishes
        '
        Me.cmdHotDishes.BackColor = System.Drawing.Color.Salmon
        Me.cmdHotDishes.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdHotDishes.ForeColor = System.Drawing.Color.White
        Me.cmdHotDishes.Location = New System.Drawing.Point(8, 76)
        Me.cmdHotDishes.Name = "cmdHotDishes"
        Me.cmdHotDishes.Size = New System.Drawing.Size(112, 56)
        Me.cmdHotDishes.TabIndex = 5
        Me.cmdHotDishes.Text = "ΖΕΣΤΑ ΠΙΑΤΑ"
        '
        'cmdBurgers
        '
        Me.cmdBurgers.BackColor = System.Drawing.Color.Salmon
        Me.cmdBurgers.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdBurgers.ForeColor = System.Drawing.Color.White
        Me.cmdBurgers.Location = New System.Drawing.Point(8, 144)
        Me.cmdBurgers.Name = "cmdBurgers"
        Me.cmdBurgers.Size = New System.Drawing.Size(112, 56)
        Me.cmdBurgers.TabIndex = 3
        Me.cmdBurgers.Text = "HUMBURGERS"
        '
        'cmdColdDishes
        '
        Me.cmdColdDishes.BackColor = System.Drawing.Color.Salmon
        Me.cmdColdDishes.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdColdDishes.ForeColor = System.Drawing.Color.White
        Me.cmdColdDishes.Location = New System.Drawing.Point(8, 8)
        Me.cmdColdDishes.Name = "cmdColdDishes"
        Me.cmdColdDishes.Size = New System.Drawing.Size(112, 56)
        Me.cmdColdDishes.TabIndex = 2
        Me.cmdColdDishes.Text = "ΚΡΥΑ ΠΙΑΤΑ"
        '
        'cmdToast
        '
        Me.cmdToast.BackColor = System.Drawing.Color.Salmon
        Me.cmdToast.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdToast.ForeColor = System.Drawing.Color.White
        Me.cmdToast.Location = New System.Drawing.Point(8, 212)
        Me.cmdToast.Name = "cmdToast"
        Me.cmdToast.Size = New System.Drawing.Size(112, 56)
        Me.cmdToast.TabIndex = 4
        Me.cmdToast.Text = "ΤΟΣΤ"
        '
        'pnlSoftdrinks
        '
        Me.pnlSoftdrinks.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlSoftdrinks.Controls.Add(Me.cmdWater)
        Me.pnlSoftdrinks.Controls.Add(Me.cmdSoda)
        Me.pnlSoftdrinks.Controls.Add(Me.cmdBottles)
        Me.pnlSoftdrinks.Controls.Add(Me.cmdCans)
        Me.pnlSoftdrinks.Location = New System.Drawing.Point(880, 40)
        Me.pnlSoftdrinks.Name = "pnlSoftdrinks"
        Me.pnlSoftdrinks.Size = New System.Drawing.Size(128, 416)
        Me.pnlSoftdrinks.TabIndex = 7
        Me.pnlSoftdrinks.Visible = False
        '
        'cmdWater
        '
        Me.cmdWater.BackColor = System.Drawing.Color.MediumVioletRed
        Me.cmdWater.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdWater.ForeColor = System.Drawing.Color.White
        Me.cmdWater.Location = New System.Drawing.Point(8, 212)
        Me.cmdWater.Name = "cmdWater"
        Me.cmdWater.Size = New System.Drawing.Size(112, 56)
        Me.cmdWater.TabIndex = 6
        Me.cmdWater.Text = "ΕΜΦΙΑΛ. ΝΕΡΟ"
        '
        'cmdSoda
        '
        Me.cmdSoda.BackColor = System.Drawing.Color.MediumVioletRed
        Me.cmdSoda.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdSoda.ForeColor = System.Drawing.Color.White
        Me.cmdSoda.Location = New System.Drawing.Point(8, 144)
        Me.cmdSoda.Name = "cmdSoda"
        Me.cmdSoda.Size = New System.Drawing.Size(112, 56)
        Me.cmdSoda.TabIndex = 5
        Me.cmdSoda.Text = "ΣΟΔΕΣ"
        '
        'cmdBottles
        '
        Me.cmdBottles.BackColor = System.Drawing.Color.MediumVioletRed
        Me.cmdBottles.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdBottles.ForeColor = System.Drawing.Color.White
        Me.cmdBottles.Location = New System.Drawing.Point(8, 76)
        Me.cmdBottles.Name = "cmdBottles"
        Me.cmdBottles.Size = New System.Drawing.Size(112, 56)
        Me.cmdBottles.TabIndex = 3
        Me.cmdBottles.Text = "ΜΠΟΥΚΑΛΙΑ"
        '
        'cmdCans
        '
        Me.cmdCans.BackColor = System.Drawing.Color.MediumVioletRed
        Me.cmdCans.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCans.ForeColor = System.Drawing.Color.White
        Me.cmdCans.Location = New System.Drawing.Point(8, 8)
        Me.cmdCans.Name = "cmdCans"
        Me.cmdCans.Size = New System.Drawing.Size(112, 56)
        Me.cmdCans.TabIndex = 2
        Me.cmdCans.Text = "ΚΟΥΤΑΚΙΑ 330ml"
        '
        'cmdBackToMainMenu
        '
        Me.cmdBackToMainMenu.BackColor = System.Drawing.Color.Chocolate
        Me.cmdBackToMainMenu.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdBackToMainMenu.ForeColor = System.Drawing.Color.White
        Me.cmdBackToMainMenu.Image = CType(resources.GetObject("cmdBackToMainMenu.Image"), System.Drawing.Image)
        Me.cmdBackToMainMenu.Location = New System.Drawing.Point(904, 672)
        Me.cmdBackToMainMenu.Name = "cmdBackToMainMenu"
        Me.cmdBackToMainMenu.Size = New System.Drawing.Size(100, 75)
        Me.cmdBackToMainMenu.TabIndex = 9
        Me.cmdBackToMainMenu.Text = "ΕΠΙΣΤΡΟΦΗ"
        Me.cmdBackToMainMenu.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdSend
        '
        Me.cmdSend.BackColor = System.Drawing.Color.MediumTurquoise
        Me.cmdSend.Enabled = False
        Me.cmdSend.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdSend.ForeColor = System.Drawing.Color.White
        Me.cmdSend.Location = New System.Drawing.Point(24, 668)
        Me.cmdSend.Name = "cmdSend"
        Me.cmdSend.Size = New System.Drawing.Size(100, 75)
        Me.cmdSend.TabIndex = 10
        Me.cmdSend.Text = "ΑΠΟΣΤΟΛΗ ΠΑΡΑΓΓΕΛΙΑΣ"
        '
        'cmdPrintCheck
        '
        Me.cmdPrintCheck.BackColor = System.Drawing.Color.LightCoral
        Me.cmdPrintCheck.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdPrintCheck.ForeColor = System.Drawing.Color.White
        Me.cmdPrintCheck.Location = New System.Drawing.Point(144, 668)
        Me.cmdPrintCheck.Name = "cmdPrintCheck"
        Me.cmdPrintCheck.Size = New System.Drawing.Size(100, 75)
        Me.cmdPrintCheck.TabIndex = 11
        Me.cmdPrintCheck.Text = "ΕΚΤΥΠΩΣΗ ΑΠΟΔΕΙΞΗΣ"
        '
        'cmdSubQuantity
        '
        Me.cmdSubQuantity.BackColor = System.Drawing.Color.LightGray
        Me.cmdSubQuantity.Enabled = False
        Me.cmdSubQuantity.Font = New System.Drawing.Font("Arial", 45.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdSubQuantity.ForeColor = System.Drawing.Color.Black
        Me.cmdSubQuantity.Location = New System.Drawing.Point(442, 184)
        Me.cmdSubQuantity.Name = "cmdSubQuantity"
        Me.cmdSubQuantity.Size = New System.Drawing.Size(60, 150)
        Me.cmdSubQuantity.TabIndex = 12
        Me.cmdSubQuantity.Text = "-"
        '
        'cmdSelfServe
        '
        Me.cmdSelfServe.BackColor = System.Drawing.Color.OliveDrab
        Me.cmdSelfServe.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdSelfServe.ForeColor = System.Drawing.Color.White
        Me.cmdSelfServe.Location = New System.Drawing.Point(264, 669)
        Me.cmdSelfServe.Name = "cmdSelfServe"
        Me.cmdSelfServe.Size = New System.Drawing.Size(100, 75)
        Me.cmdSelfServe.TabIndex = 14
        Me.cmdSelfServe.Text = "ΚΕΡΑΣΜΑ"
        '
        'cmdCategoryBack
        '
        Me.cmdCategoryBack.BackColor = System.Drawing.Color.Chocolate
        Me.cmdCategoryBack.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCategoryBack.ForeColor = System.Drawing.Color.White
        Me.cmdCategoryBack.Image = CType(resources.GetObject("cmdCategoryBack.Image"), System.Drawing.Image)
        Me.cmdCategoryBack.Location = New System.Drawing.Point(888, 392)
        Me.cmdCategoryBack.Name = "cmdCategoryBack"
        Me.cmdCategoryBack.Size = New System.Drawing.Size(112, 56)
        Me.cmdCategoryBack.TabIndex = 15
        '
        'lsvCurrent
        '
        Me.lsvCurrent.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.item, Me.quantity, Me.price, Me.hasAlchhol})
        Me.lsvCurrent.Font = New System.Drawing.Font("Courier New", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lsvCurrent.FullRowSelect = True
        Me.lsvCurrent.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lsvCurrent.Location = New System.Drawing.Point(12, 36)
        Me.lsvCurrent.MultiSelect = False
        Me.lsvCurrent.Name = "lsvCurrent"
        Me.lsvCurrent.Size = New System.Drawing.Size(414, 534)
        Me.lsvCurrent.TabIndex = 16
        Me.lsvCurrent.View = System.Windows.Forms.View.Details
        '
        'item
        '
        Me.item.Text = "Είδος"
        Me.item.Width = 268
        '
        'quantity
        '
        Me.quantity.Text = "#"
        Me.quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.quantity.Width = 45
        '
        'price
        '
        Me.price.Text = "Τιμή"
        Me.price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.price.Width = 79
        '
        'hasAlchhol
        '
        Me.hasAlchhol.Text = "Αλκοόλ"
        Me.hasAlchhol.Width = 0
        '
        'pnlBeers
        '
        Me.pnlBeers.BackColor = System.Drawing.Color.DarkGray
        Me.pnlBeers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBeers.Controls.Add(Me.cmdAmstel)
        Me.pnlBeers.Controls.Add(Me.cmdCoronaExtra)
        Me.pnlBeers.Controls.Add(Me.cmdMillerLite)
        Me.pnlBeers.Controls.Add(Me.cmdHeineken)
        Me.pnlBeers.Controls.Add(Me.cmdCarlsberg)
        Me.pnlBeers.Controls.Add(Me.cmdGoorsLight)
        Me.pnlBeers.Controls.Add(Me.cmdBudLight)
        Me.pnlBeers.Controls.Add(Me.cmdBud)
        Me.pnlBeers.Controls.Add(Me.cmdBudweiser)
        Me.pnlBeers.Location = New System.Drawing.Point(519, 39)
        Me.pnlBeers.Name = "pnlBeers"
        Me.pnlBeers.Size = New System.Drawing.Size(345, 530)
        Me.pnlBeers.TabIndex = 17
        '
        'cmdAmstel
        '
        Me.cmdAmstel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdAmstel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdAmstel.Image = CType(resources.GetObject("cmdAmstel.Image"), System.Drawing.Image)
        Me.cmdAmstel.Location = New System.Drawing.Point(260, 92)
        Me.cmdAmstel.Name = "cmdAmstel"
        Me.cmdAmstel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAmstel.Size = New System.Drawing.Size(75, 75)
        Me.cmdAmstel.TabIndex = 8
        Me.cmdAmstel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdCoronaExtra
        '
        Me.cmdCoronaExtra.BackColor = System.Drawing.Color.White
        Me.cmdCoronaExtra.Image = CType(resources.GetObject("cmdCoronaExtra.Image"), System.Drawing.Image)
        Me.cmdCoronaExtra.Location = New System.Drawing.Point(176, 92)
        Me.cmdCoronaExtra.Name = "cmdCoronaExtra"
        Me.cmdCoronaExtra.Size = New System.Drawing.Size(75, 75)
        Me.cmdCoronaExtra.TabIndex = 7
        '
        'cmdMillerLite
        '
        Me.cmdMillerLite.BackColor = System.Drawing.Color.White
        Me.cmdMillerLite.Image = CType(resources.GetObject("cmdMillerLite.Image"), System.Drawing.Image)
        Me.cmdMillerLite.Location = New System.Drawing.Point(92, 92)
        Me.cmdMillerLite.Name = "cmdMillerLite"
        Me.cmdMillerLite.Size = New System.Drawing.Size(75, 75)
        Me.cmdMillerLite.TabIndex = 6
        '
        'cmdHeineken
        '
        Me.cmdHeineken.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.cmdHeineken.Image = CType(resources.GetObject("cmdHeineken.Image"), System.Drawing.Image)
        Me.cmdHeineken.Location = New System.Drawing.Point(8, 92)
        Me.cmdHeineken.Name = "cmdHeineken"
        Me.cmdHeineken.Size = New System.Drawing.Size(75, 75)
        Me.cmdHeineken.TabIndex = 5
        '
        'cmdCarlsberg
        '
        Me.cmdCarlsberg.BackColor = System.Drawing.Color.ForestGreen
        Me.cmdCarlsberg.Image = CType(resources.GetObject("cmdCarlsberg.Image"), System.Drawing.Image)
        Me.cmdCarlsberg.Location = New System.Drawing.Point(260, 8)
        Me.cmdCarlsberg.Name = "cmdCarlsberg"
        Me.cmdCarlsberg.Size = New System.Drawing.Size(75, 75)
        Me.cmdCarlsberg.TabIndex = 4
        '
        'cmdGoorsLight
        '
        Me.cmdGoorsLight.BackColor = System.Drawing.Color.Black
        Me.cmdGoorsLight.Image = CType(resources.GetObject("cmdGoorsLight.Image"), System.Drawing.Image)
        Me.cmdGoorsLight.Location = New System.Drawing.Point(8, 176)
        Me.cmdGoorsLight.Name = "cmdGoorsLight"
        Me.cmdGoorsLight.Size = New System.Drawing.Size(75, 75)
        Me.cmdGoorsLight.TabIndex = 3
        '
        'cmdBudLight
        '
        Me.cmdBudLight.BackColor = System.Drawing.Color.LightCyan
        Me.cmdBudLight.Image = CType(resources.GetObject("cmdBudLight.Image"), System.Drawing.Image)
        Me.cmdBudLight.Location = New System.Drawing.Point(176, 8)
        Me.cmdBudLight.Name = "cmdBudLight"
        Me.cmdBudLight.Size = New System.Drawing.Size(75, 75)
        Me.cmdBudLight.TabIndex = 2
        '
        'cmdBud
        '
        Me.cmdBud.BackColor = System.Drawing.Color.GhostWhite
        Me.cmdBud.Image = CType(resources.GetObject("cmdBud.Image"), System.Drawing.Image)
        Me.cmdBud.Location = New System.Drawing.Point(92, 8)
        Me.cmdBud.Name = "cmdBud"
        Me.cmdBud.Size = New System.Drawing.Size(75, 75)
        Me.cmdBud.TabIndex = 1
        '
        'cmdBudweiser
        '
        Me.cmdBudweiser.BackColor = System.Drawing.Color.Brown
        Me.cmdBudweiser.Image = CType(resources.GetObject("cmdBudweiser.Image"), System.Drawing.Image)
        Me.cmdBudweiser.Location = New System.Drawing.Point(8, 8)
        Me.cmdBudweiser.Name = "cmdBudweiser"
        Me.cmdBudweiser.Size = New System.Drawing.Size(75, 75)
        Me.cmdBudweiser.TabIndex = 0
        '
        'pnlDrinks
        '
        Me.pnlDrinks.BackColor = System.Drawing.Color.DarkGray
        Me.pnlDrinks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDrinks.Controls.Add(Me.cmdJackDaniels)
        Me.pnlDrinks.Controls.Add(Me.cmdJohnnieWalker)
        Me.pnlDrinks.Controls.Add(Me.cmdGordons)
        Me.pnlDrinks.Controls.Add(Me.cmdCardu)
        Me.pnlDrinks.Controls.Add(Me.cmdGlenfiddich)
        Me.pnlDrinks.Controls.Add(Me.cmdJimBeam)
        Me.pnlDrinks.Controls.Add(Me.cmdChivasRegal)
        Me.pnlDrinks.Controls.Add(Me.cmdSmirnoffVodka)
        Me.pnlDrinks.Controls.Add(Me.cmdAbsolutVodka)
        Me.pnlDrinks.Location = New System.Drawing.Point(519, 39)
        Me.pnlDrinks.Name = "pnlDrinks"
        Me.pnlDrinks.Size = New System.Drawing.Size(345, 530)
        Me.pnlDrinks.TabIndex = 18
        '
        'cmdJackDaniels
        '
        Me.cmdJackDaniels.BackColor = System.Drawing.Color.Black
        Me.cmdJackDaniels.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdJackDaniels.Image = CType(resources.GetObject("cmdJackDaniels.Image"), System.Drawing.Image)
        Me.cmdJackDaniels.Location = New System.Drawing.Point(8, 176)
        Me.cmdJackDaniels.Name = "cmdJackDaniels"
        Me.cmdJackDaniels.Size = New System.Drawing.Size(75, 75)
        Me.cmdJackDaniels.TabIndex = 8
        Me.cmdJackDaniels.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdJohnnieWalker
        '
        Me.cmdJohnnieWalker.BackColor = System.Drawing.Color.White
        Me.cmdJohnnieWalker.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdJohnnieWalker.Image = CType(resources.GetObject("cmdJohnnieWalker.Image"), System.Drawing.Image)
        Me.cmdJohnnieWalker.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdJohnnieWalker.Location = New System.Drawing.Point(260, 92)
        Me.cmdJohnnieWalker.Name = "cmdJohnnieWalker"
        Me.cmdJohnnieWalker.Size = New System.Drawing.Size(75, 75)
        Me.cmdJohnnieWalker.TabIndex = 7
        Me.cmdJohnnieWalker.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdGordons
        '
        Me.cmdGordons.BackColor = System.Drawing.Color.White
        Me.cmdGordons.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdGordons.Image = CType(resources.GetObject("cmdGordons.Image"), System.Drawing.Image)
        Me.cmdGordons.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdGordons.Location = New System.Drawing.Point(176, 92)
        Me.cmdGordons.Name = "cmdGordons"
        Me.cmdGordons.Size = New System.Drawing.Size(75, 75)
        Me.cmdGordons.TabIndex = 6
        Me.cmdGordons.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdCardu
        '
        Me.cmdCardu.BackColor = System.Drawing.Color.White
        Me.cmdCardu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCardu.Image = CType(resources.GetObject("cmdCardu.Image"), System.Drawing.Image)
        Me.cmdCardu.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdCardu.Location = New System.Drawing.Point(8, 8)
        Me.cmdCardu.Name = "cmdCardu"
        Me.cmdCardu.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCardu.Size = New System.Drawing.Size(75, 75)
        Me.cmdCardu.TabIndex = 5
        Me.cmdCardu.Text = "Cardu"
        Me.cmdCardu.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdGlenfiddich
        '
        Me.cmdGlenfiddich.BackColor = System.Drawing.Color.Bisque
        Me.cmdGlenfiddich.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdGlenfiddich.Image = CType(resources.GetObject("cmdGlenfiddich.Image"), System.Drawing.Image)
        Me.cmdGlenfiddich.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdGlenfiddich.Location = New System.Drawing.Point(260, 8)
        Me.cmdGlenfiddich.Name = "cmdGlenfiddich"
        Me.cmdGlenfiddich.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdGlenfiddich.Size = New System.Drawing.Size(75, 75)
        Me.cmdGlenfiddich.TabIndex = 4
        Me.cmdGlenfiddich.Text = "Glenfiddich"
        Me.cmdGlenfiddich.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdJimBeam
        '
        Me.cmdJimBeam.BackColor = System.Drawing.Color.White
        Me.cmdJimBeam.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdJimBeam.Image = CType(resources.GetObject("cmdJimBeam.Image"), System.Drawing.Image)
        Me.cmdJimBeam.Location = New System.Drawing.Point(176, 8)
        Me.cmdJimBeam.Name = "cmdJimBeam"
        Me.cmdJimBeam.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdJimBeam.Size = New System.Drawing.Size(75, 75)
        Me.cmdJimBeam.TabIndex = 3
        Me.cmdJimBeam.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdChivasRegal
        '
        Me.cmdChivasRegal.BackColor = System.Drawing.Color.PeachPuff
        Me.cmdChivasRegal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdChivasRegal.ForeColor = System.Drawing.Color.White
        Me.cmdChivasRegal.Image = CType(resources.GetObject("cmdChivasRegal.Image"), System.Drawing.Image)
        Me.cmdChivasRegal.Location = New System.Drawing.Point(92, 8)
        Me.cmdChivasRegal.Name = "cmdChivasRegal"
        Me.cmdChivasRegal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdChivasRegal.Size = New System.Drawing.Size(75, 75)
        Me.cmdChivasRegal.TabIndex = 2
        Me.cmdChivasRegal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdSmirnoffVodka
        '
        Me.cmdSmirnoffVodka.BackColor = System.Drawing.Color.Firebrick
        Me.cmdSmirnoffVodka.Image = CType(resources.GetObject("cmdSmirnoffVodka.Image"), System.Drawing.Image)
        Me.cmdSmirnoffVodka.Location = New System.Drawing.Point(8, 92)
        Me.cmdSmirnoffVodka.Name = "cmdSmirnoffVodka"
        Me.cmdSmirnoffVodka.Size = New System.Drawing.Size(75, 75)
        Me.cmdSmirnoffVodka.TabIndex = 1
        '
        'cmdAbsolutVodka
        '
        Me.cmdAbsolutVodka.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdAbsolutVodka.Image = CType(resources.GetObject("cmdAbsolutVodka.Image"), System.Drawing.Image)
        Me.cmdAbsolutVodka.Location = New System.Drawing.Point(92, 92)
        Me.cmdAbsolutVodka.Name = "cmdAbsolutVodka"
        Me.cmdAbsolutVodka.Size = New System.Drawing.Size(75, 75)
        Me.cmdAbsolutVodka.TabIndex = 0
        '
        'pnlCocktails
        '
        Me.pnlCocktails.BackColor = System.Drawing.Color.DarkGray
        Me.pnlCocktails.BackgroundImage = CType(resources.GetObject("pnlCocktails.BackgroundImage"), System.Drawing.Image)
        Me.pnlCocktails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCocktails.Controls.Add(Me.cmdVariousCocktails)
        Me.pnlCocktails.Controls.Add(Me.cmdMargarita)
        Me.pnlCocktails.Controls.Add(Me.cmdWhiteRussian)
        Me.pnlCocktails.Controls.Add(Me.cmdB52)
        Me.pnlCocktails.Controls.Add(Me.cmdTequillaSunrise)
        Me.pnlCocktails.Location = New System.Drawing.Point(519, 39)
        Me.pnlCocktails.Name = "pnlCocktails"
        Me.pnlCocktails.Size = New System.Drawing.Size(345, 530)
        Me.pnlCocktails.TabIndex = 20
        '
        'cmdVariousCocktails
        '
        Me.cmdVariousCocktails.BackColor = System.Drawing.Color.LightCyan
        Me.cmdVariousCocktails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdVariousCocktails.Image = CType(resources.GetObject("cmdVariousCocktails.Image"), System.Drawing.Image)
        Me.cmdVariousCocktails.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdVariousCocktails.Location = New System.Drawing.Point(8, 92)
        Me.cmdVariousCocktails.Name = "cmdVariousCocktails"
        Me.cmdVariousCocktails.Size = New System.Drawing.Size(75, 75)
        Me.cmdVariousCocktails.TabIndex = 8
        Me.cmdVariousCocktails.Text = "Διάφορα"
        Me.cmdVariousCocktails.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdMargarita
        '
        Me.cmdMargarita.BackColor = System.Drawing.Color.White
        Me.cmdMargarita.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdMargarita.ForeColor = System.Drawing.Color.Black
        Me.cmdMargarita.Image = CType(resources.GetObject("cmdMargarita.Image"), System.Drawing.Image)
        Me.cmdMargarita.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdMargarita.Location = New System.Drawing.Point(8, 8)
        Me.cmdMargarita.Name = "cmdMargarita"
        Me.cmdMargarita.Size = New System.Drawing.Size(75, 75)
        Me.cmdMargarita.TabIndex = 7
        Me.cmdMargarita.Text = "Margarita"
        Me.cmdMargarita.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdWhiteRussian
        '
        Me.cmdWhiteRussian.BackColor = System.Drawing.Color.SeaShell
        Me.cmdWhiteRussian.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdWhiteRussian.Location = New System.Drawing.Point(92, 8)
        Me.cmdWhiteRussian.Name = "cmdWhiteRussian"
        Me.cmdWhiteRussian.Size = New System.Drawing.Size(75, 75)
        Me.cmdWhiteRussian.TabIndex = 6
        Me.cmdWhiteRussian.Text = "White Russian"
        '
        'cmdB52
        '
        Me.cmdB52.BackColor = System.Drawing.Color.White
        Me.cmdB52.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdB52.ForeColor = System.Drawing.Color.Black
        Me.cmdB52.Image = CType(resources.GetObject("cmdB52.Image"), System.Drawing.Image)
        Me.cmdB52.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdB52.Location = New System.Drawing.Point(176, 8)
        Me.cmdB52.Name = "cmdB52"
        Me.cmdB52.Size = New System.Drawing.Size(75, 75)
        Me.cmdB52.TabIndex = 5
        Me.cmdB52.Text = "B-52"
        Me.cmdB52.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdTequillaSunrise
        '
        Me.cmdTequillaSunrise.BackColor = System.Drawing.Color.White
        Me.cmdTequillaSunrise.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTequillaSunrise.Image = CType(resources.GetObject("cmdTequillaSunrise.Image"), System.Drawing.Image)
        Me.cmdTequillaSunrise.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdTequillaSunrise.Location = New System.Drawing.Point(260, 8)
        Me.cmdTequillaSunrise.Name = "cmdTequillaSunrise"
        Me.cmdTequillaSunrise.Size = New System.Drawing.Size(75, 75)
        Me.cmdTequillaSunrise.TabIndex = 4
        Me.cmdTequillaSunrise.Text = "Tequilla Sunrise"
        Me.cmdTequillaSunrise.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'pnlAlcoholSoftDrinks
        '
        Me.pnlAlcoholSoftDrinks.BackColor = System.Drawing.Color.DarkGray
        Me.pnlAlcoholSoftDrinks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAlcoholSoftDrinks.Controls.Add(Me.cmdBacardiBreezer)
        Me.pnlAlcoholSoftDrinks.Controls.Add(Me.cmdGordonsSpace)
        Me.pnlAlcoholSoftDrinks.Controls.Add(Me.cmdSmirnoffIce)
        Me.pnlAlcoholSoftDrinks.Location = New System.Drawing.Point(519, 39)
        Me.pnlAlcoholSoftDrinks.Name = "pnlAlcoholSoftDrinks"
        Me.pnlAlcoholSoftDrinks.Size = New System.Drawing.Size(345, 530)
        Me.pnlAlcoholSoftDrinks.TabIndex = 21
        '
        'cmdBacardiBreezer
        '
        Me.cmdBacardiBreezer.BackColor = System.Drawing.Color.White
        Me.cmdBacardiBreezer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdBacardiBreezer.ForeColor = System.Drawing.Color.Black
        Me.cmdBacardiBreezer.Image = CType(resources.GetObject("cmdBacardiBreezer.Image"), System.Drawing.Image)
        Me.cmdBacardiBreezer.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdBacardiBreezer.Location = New System.Drawing.Point(92, 8)
        Me.cmdBacardiBreezer.Name = "cmdBacardiBreezer"
        Me.cmdBacardiBreezer.Size = New System.Drawing.Size(75, 75)
        Me.cmdBacardiBreezer.TabIndex = 2
        Me.cmdBacardiBreezer.Text = "Breezer"
        Me.cmdBacardiBreezer.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdGordonsSpace
        '
        Me.cmdGordonsSpace.BackColor = System.Drawing.Color.PaleTurquoise
        Me.cmdGordonsSpace.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdGordonsSpace.ForeColor = System.Drawing.Color.Black
        Me.cmdGordonsSpace.Location = New System.Drawing.Point(176, 8)
        Me.cmdGordonsSpace.Name = "cmdGordonsSpace"
        Me.cmdGordonsSpace.Size = New System.Drawing.Size(75, 75)
        Me.cmdGordonsSpace.TabIndex = 1
        Me.cmdGordonsSpace.Text = "Gordons Space"
        '
        'cmdSmirnoffIce
        '
        Me.cmdSmirnoffIce.BackColor = System.Drawing.Color.Firebrick
        Me.cmdSmirnoffIce.Image = CType(resources.GetObject("cmdSmirnoffIce.Image"), System.Drawing.Image)
        Me.cmdSmirnoffIce.Location = New System.Drawing.Point(8, 8)
        Me.cmdSmirnoffIce.Name = "cmdSmirnoffIce"
        Me.cmdSmirnoffIce.Size = New System.Drawing.Size(75, 75)
        Me.cmdSmirnoffIce.TabIndex = 0
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.White
        Me.lblTotal.Location = New System.Drawing.Point(192, 579)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(180, 57)
        Me.lblTotal.TabIndex = 22
        Me.lblTotal.Text = "0,00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEuroSign
        '
        Me.lblEuroSign.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblEuroSign.ForeColor = System.Drawing.Color.White
        Me.lblEuroSign.Location = New System.Drawing.Point(372, 579)
        Me.lblEuroSign.Name = "lblEuroSign"
        Me.lblEuroSign.Size = New System.Drawing.Size(54, 57)
        Me.lblEuroSign.TabIndex = 23
        Me.lblEuroSign.Text = "€"
        Me.lblEuroSign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSum
        '
        Me.lblSum.AutoSize = True
        Me.lblSum.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblSum.ForeColor = System.Drawing.Color.White
        Me.lblSum.Location = New System.Drawing.Point(14, 585)
        Me.lblSum.Name = "lblSum"
        Me.lblSum.Size = New System.Drawing.Size(178, 45)
        Me.lblSum.TabIndex = 24
        Me.lblSum.Text = "ΣΥΝΟΛΟ"
        Me.lblSum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlWines
        '
        Me.pnlWines.BackColor = System.Drawing.Color.DarkGray
        Me.pnlWines.BackgroundImage = CType(resources.GetObject("pnlWines.BackgroundImage"), System.Drawing.Image)
        Me.pnlWines.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlWines.Controls.Add(Me.cmdTsantaliRed)
        Me.pnlWines.Controls.Add(Me.cmdTsantaliWhite)
        Me.pnlWines.Controls.Add(Me.cmdBoutariWhite)
        Me.pnlWines.Controls.Add(Me.cmdBoutariRed)
        Me.pnlWines.Location = New System.Drawing.Point(519, 39)
        Me.pnlWines.Name = "pnlWines"
        Me.pnlWines.Size = New System.Drawing.Size(345, 530)
        Me.pnlWines.TabIndex = 25
        '
        'cmdTsantaliRed
        '
        Me.cmdTsantaliRed.BackColor = System.Drawing.Color.White
        Me.cmdTsantaliRed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTsantaliRed.ForeColor = System.Drawing.Color.Black
        Me.cmdTsantaliRed.Image = CType(resources.GetObject("cmdTsantaliRed.Image"), System.Drawing.Image)
        Me.cmdTsantaliRed.Location = New System.Drawing.Point(176, 8)
        Me.cmdTsantaliRed.Name = "cmdTsantaliRed"
        Me.cmdTsantaliRed.Size = New System.Drawing.Size(75, 75)
        Me.cmdTsantaliRed.TabIndex = 9
        Me.cmdTsantaliRed.Text = "Τσάνταλι Κόκκινο Ποτήρι"
        Me.cmdTsantaliRed.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdTsantaliWhite
        '
        Me.cmdTsantaliWhite.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdTsantaliWhite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTsantaliWhite.ForeColor = System.Drawing.Color.Black
        Me.cmdTsantaliWhite.Image = CType(resources.GetObject("cmdTsantaliWhite.Image"), System.Drawing.Image)
        Me.cmdTsantaliWhite.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdTsantaliWhite.Location = New System.Drawing.Point(260, 8)
        Me.cmdTsantaliWhite.Name = "cmdTsantaliWhite"
        Me.cmdTsantaliWhite.Size = New System.Drawing.Size(75, 75)
        Me.cmdTsantaliWhite.TabIndex = 8
        Me.cmdTsantaliWhite.Text = "Τσάνταλι Λευκό Ποτήρι"
        Me.cmdTsantaliWhite.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdBoutariWhite
        '
        Me.cmdBoutariWhite.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdBoutariWhite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdBoutariWhite.ForeColor = System.Drawing.Color.Black
        Me.cmdBoutariWhite.Image = CType(resources.GetObject("cmdBoutariWhite.Image"), System.Drawing.Image)
        Me.cmdBoutariWhite.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdBoutariWhite.Location = New System.Drawing.Point(92, 8)
        Me.cmdBoutariWhite.Name = "cmdBoutariWhite"
        Me.cmdBoutariWhite.Size = New System.Drawing.Size(75, 75)
        Me.cmdBoutariWhite.TabIndex = 7
        Me.cmdBoutariWhite.Text = "Μπουτάρι Λευκό Ποτήρι"
        Me.cmdBoutariWhite.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdBoutariRed
        '
        Me.cmdBoutariRed.BackColor = System.Drawing.Color.White
        Me.cmdBoutariRed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdBoutariRed.ForeColor = System.Drawing.Color.Black
        Me.cmdBoutariRed.Image = CType(resources.GetObject("cmdBoutariRed.Image"), System.Drawing.Image)
        Me.cmdBoutariRed.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdBoutariRed.Location = New System.Drawing.Point(8, 8)
        Me.cmdBoutariRed.Name = "cmdBoutariRed"
        Me.cmdBoutariRed.Size = New System.Drawing.Size(75, 75)
        Me.cmdBoutariRed.TabIndex = 6
        Me.cmdBoutariRed.Text = "Μπουτάρι Κόκκινο Ποτήρι"
        Me.cmdBoutariRed.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'pnlCoffees
        '
        Me.pnlCoffees.BackColor = System.Drawing.Color.DarkGray
        Me.pnlCoffees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCoffees.Controls.Add(Me.cmdFrappe)
        Me.pnlCoffees.Controls.Add(Me.cmdNes)
        Me.pnlCoffees.Location = New System.Drawing.Point(519, 39)
        Me.pnlCoffees.Name = "pnlCoffees"
        Me.pnlCoffees.Size = New System.Drawing.Size(345, 530)
        Me.pnlCoffees.TabIndex = 26
        '
        'cmdFrappe
        '
        Me.cmdFrappe.BackColor = System.Drawing.Color.White
        Me.cmdFrappe.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdFrappe.ForeColor = System.Drawing.Color.Black
        Me.cmdFrappe.Image = CType(resources.GetObject("cmdFrappe.Image"), System.Drawing.Image)
        Me.cmdFrappe.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdFrappe.Location = New System.Drawing.Point(92, 8)
        Me.cmdFrappe.Name = "cmdFrappe"
        Me.cmdFrappe.Size = New System.Drawing.Size(75, 75)
        Me.cmdFrappe.TabIndex = 7
        Me.cmdFrappe.Text = "Frappe"
        Me.cmdFrappe.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdNes
        '
        Me.cmdNes.BackColor = System.Drawing.Color.White
        Me.cmdNes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdNes.ForeColor = System.Drawing.Color.Black
        Me.cmdNes.Image = CType(resources.GetObject("cmdNes.Image"), System.Drawing.Image)
        Me.cmdNes.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdNes.Location = New System.Drawing.Point(8, 8)
        Me.cmdNes.Name = "cmdNes"
        Me.cmdNes.Size = New System.Drawing.Size(75, 75)
        Me.cmdNes.TabIndex = 6
        Me.cmdNes.Text = "Nes Cafe"
        Me.cmdNes.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'pnlColdDishes
        '
        Me.pnlColdDishes.BackColor = System.Drawing.Color.DarkGray
        Me.pnlColdDishes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlColdDishes.Controls.Add(Me.cmdSandwich)
        Me.pnlColdDishes.Controls.Add(Me.cmdSalads)
        Me.pnlColdDishes.Location = New System.Drawing.Point(519, 39)
        Me.pnlColdDishes.Name = "pnlColdDishes"
        Me.pnlColdDishes.Size = New System.Drawing.Size(345, 530)
        Me.pnlColdDishes.TabIndex = 28
        '
        'cmdSandwich
        '
        Me.cmdSandwich.BackColor = System.Drawing.Color.Goldenrod
        Me.cmdSandwich.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdSandwich.ForeColor = System.Drawing.Color.White
        Me.cmdSandwich.Location = New System.Drawing.Point(92, 8)
        Me.cmdSandwich.Name = "cmdSandwich"
        Me.cmdSandwich.Size = New System.Drawing.Size(75, 75)
        Me.cmdSandwich.TabIndex = 7
        Me.cmdSandwich.Text = "Κρύα Σάντουϊτς"
        '
        'cmdSalads
        '
        Me.cmdSalads.BackColor = System.Drawing.Color.LimeGreen
        Me.cmdSalads.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdSalads.ForeColor = System.Drawing.Color.White
        Me.cmdSalads.Image = CType(resources.GetObject("cmdSalads.Image"), System.Drawing.Image)
        Me.cmdSalads.Location = New System.Drawing.Point(8, 8)
        Me.cmdSalads.Name = "cmdSalads"
        Me.cmdSalads.Size = New System.Drawing.Size(75, 75)
        Me.cmdSalads.TabIndex = 6
        Me.cmdSalads.Text = "Σαλάτες"
        Me.cmdSalads.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'pnlJuices
        '
        Me.pnlJuices.BackColor = System.Drawing.Color.DarkGray
        Me.pnlJuices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlJuices.Controls.Add(Me.cmdMixed)
        Me.pnlJuices.Controls.Add(Me.cmdApricot)
        Me.pnlJuices.Controls.Add(Me.cmdCherry)
        Me.pnlJuices.Controls.Add(Me.cmdBanana)
        Me.pnlJuices.Controls.Add(Me.cmdPeach)
        Me.pnlJuices.Controls.Add(Me.cmdOrange)
        Me.pnlJuices.Location = New System.Drawing.Point(519, 39)
        Me.pnlJuices.Name = "pnlJuices"
        Me.pnlJuices.Size = New System.Drawing.Size(345, 530)
        Me.pnlJuices.TabIndex = 29
        '
        'cmdMixed
        '
        Me.cmdMixed.BackColor = System.Drawing.Color.MediumTurquoise
        Me.cmdMixed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdMixed.ForeColor = System.Drawing.Color.Black
        Me.cmdMixed.Location = New System.Drawing.Point(92, 92)
        Me.cmdMixed.Name = "cmdMixed"
        Me.cmdMixed.Size = New System.Drawing.Size(75, 75)
        Me.cmdMixed.TabIndex = 11
        Me.cmdMixed.Text = "Χυμός Ανάμικτος"
        '
        'cmdApricot
        '
        Me.cmdApricot.BackColor = System.Drawing.Color.DarkOrange
        Me.cmdApricot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdApricot.ForeColor = System.Drawing.Color.Black
        Me.cmdApricot.Location = New System.Drawing.Point(8, 92)
        Me.cmdApricot.Name = "cmdApricot"
        Me.cmdApricot.Size = New System.Drawing.Size(75, 75)
        Me.cmdApricot.TabIndex = 10
        Me.cmdApricot.Text = "Χυμός Βερίκοκο"
        '
        'cmdCherry
        '
        Me.cmdCherry.BackColor = System.Drawing.Color.Crimson
        Me.cmdCherry.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCherry.ForeColor = System.Drawing.Color.Black
        Me.cmdCherry.Location = New System.Drawing.Point(260, 8)
        Me.cmdCherry.Name = "cmdCherry"
        Me.cmdCherry.Size = New System.Drawing.Size(75, 75)
        Me.cmdCherry.TabIndex = 9
        Me.cmdCherry.Text = "Χυμός Βύσσινο"
        '
        'cmdBanana
        '
        Me.cmdBanana.BackColor = System.Drawing.Color.Gold
        Me.cmdBanana.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdBanana.ForeColor = System.Drawing.Color.Black
        Me.cmdBanana.Location = New System.Drawing.Point(176, 8)
        Me.cmdBanana.Name = "cmdBanana"
        Me.cmdBanana.Size = New System.Drawing.Size(75, 75)
        Me.cmdBanana.TabIndex = 8
        Me.cmdBanana.Text = "Χυμός Μπανάνα"
        '
        'cmdPeach
        '
        Me.cmdPeach.BackColor = System.Drawing.Color.PeachPuff
        Me.cmdPeach.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdPeach.ForeColor = System.Drawing.Color.Black
        Me.cmdPeach.Location = New System.Drawing.Point(92, 8)
        Me.cmdPeach.Name = "cmdPeach"
        Me.cmdPeach.Size = New System.Drawing.Size(75, 75)
        Me.cmdPeach.TabIndex = 7
        Me.cmdPeach.Text = "Χυμός Ροδάκινο"
        '
        'cmdOrange
        '
        Me.cmdOrange.BackColor = System.Drawing.Color.White
        Me.cmdOrange.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdOrange.ForeColor = System.Drawing.Color.Black
        Me.cmdOrange.Image = CType(resources.GetObject("cmdOrange.Image"), System.Drawing.Image)
        Me.cmdOrange.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdOrange.Location = New System.Drawing.Point(8, 8)
        Me.cmdOrange.Name = "cmdOrange"
        Me.cmdOrange.Size = New System.Drawing.Size(75, 75)
        Me.cmdOrange.TabIndex = 6
        Me.cmdOrange.Text = "Χυμός Πορτοκάλι"
        Me.cmdOrange.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'pnlTea
        '
        Me.pnlTea.BackColor = System.Drawing.Color.DarkGray
        Me.pnlTea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTea.Controls.Add(Me.cmdHotTea)
        Me.pnlTea.Controls.Add(Me.cmdLipton)
        Me.pnlTea.Controls.Add(Me.cmdIceTea)
        Me.pnlTea.Location = New System.Drawing.Point(519, 39)
        Me.pnlTea.Name = "pnlTea"
        Me.pnlTea.Size = New System.Drawing.Size(345, 530)
        Me.pnlTea.TabIndex = 30
        '
        'cmdHotTea
        '
        Me.cmdHotTea.BackColor = System.Drawing.Color.Sienna
        Me.cmdHotTea.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdHotTea.ForeColor = System.Drawing.Color.White
        Me.cmdHotTea.Location = New System.Drawing.Point(176, 8)
        Me.cmdHotTea.Name = "cmdHotTea"
        Me.cmdHotTea.Size = New System.Drawing.Size(75, 75)
        Me.cmdHotTea.TabIndex = 8
        Me.cmdHotTea.Text = "Τσάϊ"
        '
        'cmdLipton
        '
        Me.cmdLipton.BackColor = System.Drawing.Color.White
        Me.cmdLipton.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdLipton.ForeColor = System.Drawing.Color.White
        Me.cmdLipton.Image = CType(resources.GetObject("cmdLipton.Image"), System.Drawing.Image)
        Me.cmdLipton.Location = New System.Drawing.Point(8, 8)
        Me.cmdLipton.Name = "cmdLipton"
        Me.cmdLipton.Size = New System.Drawing.Size(75, 75)
        Me.cmdLipton.TabIndex = 7
        '
        'cmdIceTea
        '
        Me.cmdIceTea.BackColor = System.Drawing.Color.White
        Me.cmdIceTea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdIceTea.ForeColor = System.Drawing.Color.Black
        Me.cmdIceTea.Image = CType(resources.GetObject("cmdIceTea.Image"), System.Drawing.Image)
        Me.cmdIceTea.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdIceTea.Location = New System.Drawing.Point(92, 8)
        Me.cmdIceTea.Name = "cmdIceTea"
        Me.cmdIceTea.Size = New System.Drawing.Size(75, 75)
        Me.cmdIceTea.TabIndex = 6
        Me.cmdIceTea.Text = "Ice Tea"
        Me.cmdIceTea.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'pnlChoco
        '
        Me.pnlChoco.BackColor = System.Drawing.Color.DarkGray
        Me.pnlChoco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlChoco.Controls.Add(Me.cmdColdChoco)
        Me.pnlChoco.Controls.Add(Me.cmdHotChoco)
        Me.pnlChoco.Location = New System.Drawing.Point(519, 39)
        Me.pnlChoco.Name = "pnlChoco"
        Me.pnlChoco.Size = New System.Drawing.Size(345, 530)
        Me.pnlChoco.TabIndex = 31
        '
        'cmdColdChoco
        '
        Me.cmdColdChoco.BackColor = System.Drawing.Color.SaddleBrown
        Me.cmdColdChoco.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdColdChoco.ForeColor = System.Drawing.Color.White
        Me.cmdColdChoco.Location = New System.Drawing.Point(92, 8)
        Me.cmdColdChoco.Name = "cmdColdChoco"
        Me.cmdColdChoco.Size = New System.Drawing.Size(75, 75)
        Me.cmdColdChoco.TabIndex = 7
        Me.cmdColdChoco.Text = "Κρύα Σοκολάτα"
        '
        'cmdHotChoco
        '
        Me.cmdHotChoco.BackColor = System.Drawing.Color.White
        Me.cmdHotChoco.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdHotChoco.ForeColor = System.Drawing.Color.Black
        Me.cmdHotChoco.Image = CType(resources.GetObject("cmdHotChoco.Image"), System.Drawing.Image)
        Me.cmdHotChoco.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdHotChoco.Location = New System.Drawing.Point(8, 8)
        Me.cmdHotChoco.Name = "cmdHotChoco"
        Me.cmdHotChoco.Size = New System.Drawing.Size(75, 75)
        Me.cmdHotChoco.TabIndex = 6
        Me.cmdHotChoco.Text = "Ζεστή Σοκολάτα"
        Me.cmdHotChoco.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'pnlMilkShake
        '
        Me.pnlMilkShake.BackColor = System.Drawing.Color.DarkGray
        Me.pnlMilkShake.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMilkShake.Controls.Add(Me.cmdMShake)
        Me.pnlMilkShake.Location = New System.Drawing.Point(519, 39)
        Me.pnlMilkShake.Name = "pnlMilkShake"
        Me.pnlMilkShake.Size = New System.Drawing.Size(345, 530)
        Me.pnlMilkShake.TabIndex = 32
        '
        'cmdMShake
        '
        Me.cmdMShake.BackColor = System.Drawing.Color.White
        Me.cmdMShake.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdMShake.ForeColor = System.Drawing.Color.Black
        Me.cmdMShake.Image = CType(resources.GetObject("cmdMShake.Image"), System.Drawing.Image)
        Me.cmdMShake.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdMShake.Location = New System.Drawing.Point(8, 8)
        Me.cmdMShake.Name = "cmdMShake"
        Me.cmdMShake.Size = New System.Drawing.Size(75, 75)
        Me.cmdMShake.TabIndex = 6
        Me.cmdMShake.Text = "Milk Shake"
        Me.cmdMShake.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'pnlWater
        '
        Me.pnlWater.BackColor = System.Drawing.Color.DarkGray
        Me.pnlWater.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlWater.Controls.Add(Me.cmdWater1000)
        Me.pnlWater.Controls.Add(Me.cmdWater500)
        Me.pnlWater.Controls.Add(Me.cmdYdor)
        Me.pnlWater.Location = New System.Drawing.Point(519, 39)
        Me.pnlWater.Name = "pnlWater"
        Me.pnlWater.Size = New System.Drawing.Size(345, 530)
        Me.pnlWater.TabIndex = 33
        '
        'cmdWater1000
        '
        Me.cmdWater1000.BackColor = System.Drawing.Color.DarkTurquoise
        Me.cmdWater1000.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdWater1000.ForeColor = System.Drawing.Color.White
        Me.cmdWater1000.Location = New System.Drawing.Point(176, 8)
        Me.cmdWater1000.Name = "cmdWater1000"
        Me.cmdWater1000.Size = New System.Drawing.Size(75, 75)
        Me.cmdWater1000.TabIndex = 8
        Me.cmdWater1000.Text = "Νερό 1000ml"
        '
        'cmdWater500
        '
        Me.cmdWater500.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdWater500.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdWater500.ForeColor = System.Drawing.Color.White
        Me.cmdWater500.Location = New System.Drawing.Point(92, 8)
        Me.cmdWater500.Name = "cmdWater500"
        Me.cmdWater500.Size = New System.Drawing.Size(75, 75)
        Me.cmdWater500.TabIndex = 7
        Me.cmdWater500.Text = "Νερό 500ml"
        '
        'cmdYdor
        '
        Me.cmdYdor.BackColor = System.Drawing.Color.White
        Me.cmdYdor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdYdor.ForeColor = System.Drawing.Color.White
        Me.cmdYdor.Image = CType(resources.GetObject("cmdYdor.Image"), System.Drawing.Image)
        Me.cmdYdor.Location = New System.Drawing.Point(8, 8)
        Me.cmdYdor.Name = "cmdYdor"
        Me.cmdYdor.Size = New System.Drawing.Size(75, 75)
        Me.cmdYdor.TabIndex = 6
        '
        'pnlSoda
        '
        Me.pnlSoda.BackColor = System.Drawing.Color.DarkGray
        Me.pnlSoda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSoda.Controls.Add(Me.cmdTuborg)
        Me.pnlSoda.Controls.Add(Me.cmdSouroti)
        Me.pnlSoda.Controls.Add(Me.cmdSourotiOrange)
        Me.pnlSoda.Location = New System.Drawing.Point(519, 39)
        Me.pnlSoda.Name = "pnlSoda"
        Me.pnlSoda.Size = New System.Drawing.Size(345, 530)
        Me.pnlSoda.TabIndex = 34
        '
        'cmdTuborg
        '
        Me.cmdTuborg.BackColor = System.Drawing.Color.Firebrick
        Me.cmdTuborg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTuborg.ForeColor = System.Drawing.Color.White
        Me.cmdTuborg.Location = New System.Drawing.Point(176, 8)
        Me.cmdTuborg.Name = "cmdTuborg"
        Me.cmdTuborg.Size = New System.Drawing.Size(75, 75)
        Me.cmdTuborg.TabIndex = 8
        Me.cmdTuborg.Text = "Tuborg"
        '
        'cmdSouroti
        '
        Me.cmdSouroti.BackColor = System.Drawing.Color.RoyalBlue
        Me.cmdSouroti.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdSouroti.ForeColor = System.Drawing.Color.White
        Me.cmdSouroti.Location = New System.Drawing.Point(92, 8)
        Me.cmdSouroti.Name = "cmdSouroti"
        Me.cmdSouroti.Size = New System.Drawing.Size(75, 75)
        Me.cmdSouroti.TabIndex = 7
        Me.cmdSouroti.Text = "Σουρωτή"
        '
        'cmdSourotiOrange
        '
        Me.cmdSourotiOrange.BackColor = System.Drawing.Color.White
        Me.cmdSourotiOrange.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdSourotiOrange.ForeColor = System.Drawing.Color.White
        Me.cmdSourotiOrange.Image = CType(resources.GetObject("cmdSourotiOrange.Image"), System.Drawing.Image)
        Me.cmdSourotiOrange.Location = New System.Drawing.Point(8, 8)
        Me.cmdSourotiOrange.Name = "cmdSourotiOrange"
        Me.cmdSourotiOrange.Size = New System.Drawing.Size(75, 75)
        Me.cmdSourotiOrange.TabIndex = 6
        '
        'pnlBottles
        '
        Me.pnlBottles.BackColor = System.Drawing.Color.DarkGray
        Me.pnlBottles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBottles.Controls.Add(Me.cmdDrPepperBottle)
        Me.pnlBottles.Controls.Add(Me.cmdSpriteBottle)
        Me.pnlBottles.Controls.Add(Me.cmdFantaBottle)
        Me.pnlBottles.Controls.Add(Me.cmd7upbottle)
        Me.pnlBottles.Controls.Add(Me.cmdPepsiBottle)
        Me.pnlBottles.Controls.Add(Me.cmdCocaBottle)
        Me.pnlBottles.Location = New System.Drawing.Point(519, 39)
        Me.pnlBottles.Name = "pnlBottles"
        Me.pnlBottles.Size = New System.Drawing.Size(345, 530)
        Me.pnlBottles.TabIndex = 36
        '
        'cmdDrPepperBottle
        '
        Me.cmdDrPepperBottle.BackColor = System.Drawing.Color.DarkRed
        Me.cmdDrPepperBottle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdDrPepperBottle.ForeColor = System.Drawing.Color.White
        Me.cmdDrPepperBottle.Image = CType(resources.GetObject("cmdDrPepperBottle.Image"), System.Drawing.Image)
        Me.cmdDrPepperBottle.Location = New System.Drawing.Point(176, 8)
        Me.cmdDrPepperBottle.Name = "cmdDrPepperBottle"
        Me.cmdDrPepperBottle.Size = New System.Drawing.Size(75, 75)
        Me.cmdDrPepperBottle.TabIndex = 17
        Me.cmdDrPepperBottle.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cmdSpriteBottle
        '
        Me.cmdSpriteBottle.BackColor = System.Drawing.Color.White
        Me.cmdSpriteBottle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdSpriteBottle.ForeColor = System.Drawing.Color.White
        Me.cmdSpriteBottle.Image = CType(resources.GetObject("cmdSpriteBottle.Image"), System.Drawing.Image)
        Me.cmdSpriteBottle.Location = New System.Drawing.Point(92, 8)
        Me.cmdSpriteBottle.Name = "cmdSpriteBottle"
        Me.cmdSpriteBottle.Size = New System.Drawing.Size(75, 75)
        Me.cmdSpriteBottle.TabIndex = 16
        Me.cmdSpriteBottle.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cmdFantaBottle
        '
        Me.cmdFantaBottle.BackColor = System.Drawing.Color.OrangeRed
        Me.cmdFantaBottle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdFantaBottle.ForeColor = System.Drawing.Color.White
        Me.cmdFantaBottle.Image = CType(resources.GetObject("cmdFantaBottle.Image"), System.Drawing.Image)
        Me.cmdFantaBottle.Location = New System.Drawing.Point(92, 92)
        Me.cmdFantaBottle.Name = "cmdFantaBottle"
        Me.cmdFantaBottle.Size = New System.Drawing.Size(75, 75)
        Me.cmdFantaBottle.TabIndex = 15
        Me.cmdFantaBottle.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cmd7upbottle
        '
        Me.cmd7upbottle.BackColor = System.Drawing.Color.White
        Me.cmd7upbottle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmd7upbottle.ForeColor = System.Drawing.Color.White
        Me.cmd7upbottle.Image = CType(resources.GetObject("cmd7upbottle.Image"), System.Drawing.Image)
        Me.cmd7upbottle.Location = New System.Drawing.Point(8, 8)
        Me.cmd7upbottle.Name = "cmd7upbottle"
        Me.cmd7upbottle.Size = New System.Drawing.Size(75, 75)
        Me.cmd7upbottle.TabIndex = 14
        Me.cmd7upbottle.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cmdPepsiBottle
        '
        Me.cmdPepsiBottle.BackColor = System.Drawing.Color.White
        Me.cmdPepsiBottle.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdPepsiBottle.ForeColor = System.Drawing.Color.White
        Me.cmdPepsiBottle.Image = CType(resources.GetObject("cmdPepsiBottle.Image"), System.Drawing.Image)
        Me.cmdPepsiBottle.Location = New System.Drawing.Point(260, 8)
        Me.cmdPepsiBottle.Name = "cmdPepsiBottle"
        Me.cmdPepsiBottle.Size = New System.Drawing.Size(75, 75)
        Me.cmdPepsiBottle.TabIndex = 13
        '
        'cmdCocaBottle
        '
        Me.cmdCocaBottle.BackColor = System.Drawing.Color.White
        Me.cmdCocaBottle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCocaBottle.ForeColor = System.Drawing.Color.White
        Me.cmdCocaBottle.Image = CType(resources.GetObject("cmdCocaBottle.Image"), System.Drawing.Image)
        Me.cmdCocaBottle.Location = New System.Drawing.Point(8, 92)
        Me.cmdCocaBottle.Name = "cmdCocaBottle"
        Me.cmdCocaBottle.Size = New System.Drawing.Size(75, 75)
        Me.cmdCocaBottle.TabIndex = 12
        Me.cmdCocaBottle.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'pnlCans
        '
        Me.pnlCans.BackColor = System.Drawing.Color.DarkGray
        Me.pnlCans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCans.Controls.Add(Me.cmdDrPepper)
        Me.pnlCans.Controls.Add(Me.cmdSprite)
        Me.pnlCans.Controls.Add(Me.cmdFanta)
        Me.pnlCans.Controls.Add(Me.cmd7up)
        Me.pnlCans.Controls.Add(Me.cmdPepsi)
        Me.pnlCans.Controls.Add(Me.cmdCocaCola)
        Me.pnlCans.Location = New System.Drawing.Point(519, 39)
        Me.pnlCans.Name = "pnlCans"
        Me.pnlCans.Size = New System.Drawing.Size(345, 530)
        Me.pnlCans.TabIndex = 37
        '
        'cmdDrPepper
        '
        Me.cmdDrPepper.BackColor = System.Drawing.Color.DarkRed
        Me.cmdDrPepper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdDrPepper.ForeColor = System.Drawing.Color.White
        Me.cmdDrPepper.Image = CType(resources.GetObject("cmdDrPepper.Image"), System.Drawing.Image)
        Me.cmdDrPepper.Location = New System.Drawing.Point(92, 92)
        Me.cmdDrPepper.Name = "cmdDrPepper"
        Me.cmdDrPepper.Size = New System.Drawing.Size(75, 75)
        Me.cmdDrPepper.TabIndex = 11
        Me.cmdDrPepper.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cmdSprite
        '
        Me.cmdSprite.BackColor = System.Drawing.Color.White
        Me.cmdSprite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdSprite.ForeColor = System.Drawing.Color.White
        Me.cmdSprite.Image = CType(resources.GetObject("cmdSprite.Image"), System.Drawing.Image)
        Me.cmdSprite.Location = New System.Drawing.Point(8, 92)
        Me.cmdSprite.Name = "cmdSprite"
        Me.cmdSprite.Size = New System.Drawing.Size(75, 75)
        Me.cmdSprite.TabIndex = 10
        Me.cmdSprite.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cmdFanta
        '
        Me.cmdFanta.BackColor = System.Drawing.Color.OrangeRed
        Me.cmdFanta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdFanta.ForeColor = System.Drawing.Color.White
        Me.cmdFanta.Image = CType(resources.GetObject("cmdFanta.Image"), System.Drawing.Image)
        Me.cmdFanta.Location = New System.Drawing.Point(260, 8)
        Me.cmdFanta.Name = "cmdFanta"
        Me.cmdFanta.Size = New System.Drawing.Size(75, 75)
        Me.cmdFanta.TabIndex = 9
        Me.cmdFanta.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cmd7up
        '
        Me.cmd7up.BackColor = System.Drawing.Color.White
        Me.cmd7up.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmd7up.ForeColor = System.Drawing.Color.White
        Me.cmd7up.Image = CType(resources.GetObject("cmd7up.Image"), System.Drawing.Image)
        Me.cmd7up.Location = New System.Drawing.Point(176, 8)
        Me.cmd7up.Name = "cmd7up"
        Me.cmd7up.Size = New System.Drawing.Size(75, 75)
        Me.cmd7up.TabIndex = 8
        Me.cmd7up.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cmdPepsi
        '
        Me.cmdPepsi.BackColor = System.Drawing.Color.MediumBlue
        Me.cmdPepsi.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdPepsi.ForeColor = System.Drawing.Color.White
        Me.cmdPepsi.Image = CType(resources.GetObject("cmdPepsi.Image"), System.Drawing.Image)
        Me.cmdPepsi.Location = New System.Drawing.Point(92, 8)
        Me.cmdPepsi.Name = "cmdPepsi"
        Me.cmdPepsi.Size = New System.Drawing.Size(75, 75)
        Me.cmdPepsi.TabIndex = 7
        '
        'cmdCocaCola
        '
        Me.cmdCocaCola.BackColor = System.Drawing.Color.White
        Me.cmdCocaCola.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCocaCola.ForeColor = System.Drawing.Color.White
        Me.cmdCocaCola.Image = CType(resources.GetObject("cmdCocaCola.Image"), System.Drawing.Image)
        Me.cmdCocaCola.Location = New System.Drawing.Point(8, 8)
        Me.cmdCocaCola.Name = "cmdCocaCola"
        Me.cmdCocaCola.Size = New System.Drawing.Size(75, 75)
        Me.cmdCocaCola.TabIndex = 6
        Me.cmdCocaCola.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'pnlHotDishes
        '
        Me.pnlHotDishes.BackColor = System.Drawing.Color.DarkGray
        Me.pnlHotDishes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlHotDishes.Controls.Add(Me.cmdSteak2)
        Me.pnlHotDishes.Controls.Add(Me.cmdSteak)
        Me.pnlHotDishes.Controls.Add(Me.cmdPizza)
        Me.pnlHotDishes.Controls.Add(Me.cmdFrenchFries)
        Me.pnlHotDishes.Controls.Add(Me.cmdEggs)
        Me.pnlHotDishes.Controls.Add(Me.cmdOvenPotato)
        Me.pnlHotDishes.Location = New System.Drawing.Point(519, 39)
        Me.pnlHotDishes.Name = "pnlHotDishes"
        Me.pnlHotDishes.Size = New System.Drawing.Size(345, 530)
        Me.pnlHotDishes.TabIndex = 38
        '
        'cmdSteak2
        '
        Me.cmdSteak2.BackColor = System.Drawing.Color.White
        Me.cmdSteak2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdSteak2.ForeColor = System.Drawing.Color.Black
        Me.cmdSteak2.Image = CType(resources.GetObject("cmdSteak2.Image"), System.Drawing.Image)
        Me.cmdSteak2.Location = New System.Drawing.Point(92, 92)
        Me.cmdSteak2.Name = "cmdSteak2"
        Me.cmdSteak2.Size = New System.Drawing.Size(75, 75)
        Me.cmdSteak2.TabIndex = 9
        Me.cmdSteak2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdSteak
        '
        Me.cmdSteak.BackColor = System.Drawing.Color.SaddleBrown
        Me.cmdSteak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdSteak.ForeColor = System.Drawing.Color.Black
        Me.cmdSteak.Image = CType(resources.GetObject("cmdSteak.Image"), System.Drawing.Image)
        Me.cmdSteak.Location = New System.Drawing.Point(8, 92)
        Me.cmdSteak.Name = "cmdSteak"
        Me.cmdSteak.Size = New System.Drawing.Size(75, 75)
        Me.cmdSteak.TabIndex = 8
        Me.cmdSteak.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdPizza
        '
        Me.cmdPizza.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.cmdPizza.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdPizza.ForeColor = System.Drawing.Color.Black
        Me.cmdPizza.Image = CType(resources.GetObject("cmdPizza.Image"), System.Drawing.Image)
        Me.cmdPizza.Location = New System.Drawing.Point(260, 8)
        Me.cmdPizza.Name = "cmdPizza"
        Me.cmdPizza.Size = New System.Drawing.Size(75, 75)
        Me.cmdPizza.TabIndex = 7
        Me.cmdPizza.Text = "Pizza"
        Me.cmdPizza.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdFrenchFries
        '
        Me.cmdFrenchFries.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.cmdFrenchFries.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdFrenchFries.ForeColor = System.Drawing.Color.Black
        Me.cmdFrenchFries.Image = CType(resources.GetObject("cmdFrenchFries.Image"), System.Drawing.Image)
        Me.cmdFrenchFries.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdFrenchFries.Location = New System.Drawing.Point(176, 8)
        Me.cmdFrenchFries.Name = "cmdFrenchFries"
        Me.cmdFrenchFries.Size = New System.Drawing.Size(75, 75)
        Me.cmdFrenchFries.TabIndex = 6
        Me.cmdFrenchFries.Text = "Τηγανητές Πατάτες"
        Me.cmdFrenchFries.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdEggs
        '
        Me.cmdEggs.BackColor = System.Drawing.Color.DarkBlue
        Me.cmdEggs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdEggs.ForeColor = System.Drawing.Color.White
        Me.cmdEggs.Image = CType(resources.GetObject("cmdEggs.Image"), System.Drawing.Image)
        Me.cmdEggs.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdEggs.Location = New System.Drawing.Point(92, 8)
        Me.cmdEggs.Name = "cmdEggs"
        Me.cmdEggs.Size = New System.Drawing.Size(75, 75)
        Me.cmdEggs.TabIndex = 5
        Me.cmdEggs.Text = "Ομελέτες / Αυγά"
        Me.cmdEggs.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdOvenPotato
        '
        Me.cmdOvenPotato.BackColor = System.Drawing.Color.Crimson
        Me.cmdOvenPotato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdOvenPotato.ForeColor = System.Drawing.Color.White
        Me.cmdOvenPotato.Image = CType(resources.GetObject("cmdOvenPotato.Image"), System.Drawing.Image)
        Me.cmdOvenPotato.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdOvenPotato.Location = New System.Drawing.Point(8, 8)
        Me.cmdOvenPotato.Name = "cmdOvenPotato"
        Me.cmdOvenPotato.Size = New System.Drawing.Size(75, 75)
        Me.cmdOvenPotato.TabIndex = 4
        Me.cmdOvenPotato.Text = "Πατάτα Φούρνου"
        Me.cmdOvenPotato.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'pnlBurgers
        '
        Me.pnlBurgers.BackColor = System.Drawing.Color.DarkGray
        Me.pnlBurgers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBurgers.Controls.Add(Me.cmdHumBurger)
        Me.pnlBurgers.Controls.Add(Me.cmdCheeseBurger)
        Me.pnlBurgers.Controls.Add(Me.cmdBurgerGalore)
        Me.pnlBurgers.Controls.Add(Me.cmdHotDog)
        Me.pnlBurgers.Controls.Add(Me.cmdDoubleBurger)
        Me.pnlBurgers.Location = New System.Drawing.Point(519, 39)
        Me.pnlBurgers.Name = "pnlBurgers"
        Me.pnlBurgers.Size = New System.Drawing.Size(345, 530)
        Me.pnlBurgers.TabIndex = 39
        '
        'cmdHumBurger
        '
        Me.cmdHumBurger.BackColor = System.Drawing.Color.Firebrick
        Me.cmdHumBurger.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdHumBurger.ForeColor = System.Drawing.Color.White
        Me.cmdHumBurger.Image = CType(resources.GetObject("cmdHumBurger.Image"), System.Drawing.Image)
        Me.cmdHumBurger.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdHumBurger.Location = New System.Drawing.Point(8, 8)
        Me.cmdHumBurger.Name = "cmdHumBurger"
        Me.cmdHumBurger.Size = New System.Drawing.Size(75, 75)
        Me.cmdHumBurger.TabIndex = 11
        Me.cmdHumBurger.Text = "Hum Burger"
        Me.cmdHumBurger.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdCheeseBurger
        '
        Me.cmdCheeseBurger.BackColor = System.Drawing.Color.Gold
        Me.cmdCheeseBurger.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCheeseBurger.ForeColor = System.Drawing.Color.Black
        Me.cmdCheeseBurger.Image = CType(resources.GetObject("cmdCheeseBurger.Image"), System.Drawing.Image)
        Me.cmdCheeseBurger.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdCheeseBurger.Location = New System.Drawing.Point(92, 8)
        Me.cmdCheeseBurger.Name = "cmdCheeseBurger"
        Me.cmdCheeseBurger.Size = New System.Drawing.Size(75, 75)
        Me.cmdCheeseBurger.TabIndex = 8
        Me.cmdCheeseBurger.Text = "Cheese Burger"
        Me.cmdCheeseBurger.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdBurgerGalore
        '
        Me.cmdBurgerGalore.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.cmdBurgerGalore.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdBurgerGalore.ForeColor = System.Drawing.Color.White
        Me.cmdBurgerGalore.Image = CType(resources.GetObject("cmdBurgerGalore.Image"), System.Drawing.Image)
        Me.cmdBurgerGalore.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdBurgerGalore.Location = New System.Drawing.Point(260, 8)
        Me.cmdBurgerGalore.Name = "cmdBurgerGalore"
        Me.cmdBurgerGalore.Size = New System.Drawing.Size(75, 75)
        Me.cmdBurgerGalore.TabIndex = 6
        Me.cmdBurgerGalore.Text = "Burger Galore"
        Me.cmdBurgerGalore.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdHotDog
        '
        Me.cmdHotDog.BackColor = System.Drawing.Color.ForestGreen
        Me.cmdHotDog.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdHotDog.ForeColor = System.Drawing.Color.White
        Me.cmdHotDog.Image = CType(resources.GetObject("cmdHotDog.Image"), System.Drawing.Image)
        Me.cmdHotDog.Location = New System.Drawing.Point(8, 92)
        Me.cmdHotDog.Name = "cmdHotDog"
        Me.cmdHotDog.Size = New System.Drawing.Size(75, 75)
        Me.cmdHotDog.TabIndex = 5
        Me.cmdHotDog.Text = "Hot Dog"
        Me.cmdHotDog.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdDoubleBurger
        '
        Me.cmdDoubleBurger.BackColor = System.Drawing.Color.RosyBrown
        Me.cmdDoubleBurger.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdDoubleBurger.ForeColor = System.Drawing.Color.White
        Me.cmdDoubleBurger.Image = CType(resources.GetObject("cmdDoubleBurger.Image"), System.Drawing.Image)
        Me.cmdDoubleBurger.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdDoubleBurger.Location = New System.Drawing.Point(176, 8)
        Me.cmdDoubleBurger.Name = "cmdDoubleBurger"
        Me.cmdDoubleBurger.Size = New System.Drawing.Size(75, 75)
        Me.cmdDoubleBurger.TabIndex = 4
        Me.cmdDoubleBurger.Text = "Double Burger"
        Me.cmdDoubleBurger.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'pnlToast
        '
        Me.pnlToast.BackColor = System.Drawing.Color.DarkGray
        Me.pnlToast.BackgroundImage = CType(resources.GetObject("pnlToast.BackgroundImage"), System.Drawing.Image)
        Me.pnlToast.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlToast.Controls.Add(Me.cmdToastChipsBrown)
        Me.pnlToast.Controls.Add(Me.cmdToastCheeseBrown)
        Me.pnlToast.Controls.Add(Me.cmdToastHamCheeseBrown)
        Me.pnlToast.Controls.Add(Me.cmdToastChips)
        Me.pnlToast.Controls.Add(Me.cmdToastCheese)
        Me.pnlToast.Controls.Add(Me.cmdToastHamCheese)
        Me.pnlToast.Location = New System.Drawing.Point(519, 39)
        Me.pnlToast.Name = "pnlToast"
        Me.pnlToast.Size = New System.Drawing.Size(345, 530)
        Me.pnlToast.TabIndex = 40
        '
        'cmdToastChipsBrown
        '
        Me.cmdToastChipsBrown.BackColor = System.Drawing.Color.SaddleBrown
        Me.cmdToastChipsBrown.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdToastChipsBrown.ForeColor = System.Drawing.Color.White
        Me.cmdToastChipsBrown.Location = New System.Drawing.Point(176, 92)
        Me.cmdToastChipsBrown.Name = "cmdToastChipsBrown"
        Me.cmdToastChipsBrown.Size = New System.Drawing.Size(75, 75)
        Me.cmdToastChipsBrown.TabIndex = 11
        Me.cmdToastChipsBrown.Text = "Τοστ με Πατατάκια (Μαύρο Ψωμί)"
        '
        'cmdToastCheeseBrown
        '
        Me.cmdToastCheeseBrown.BackColor = System.Drawing.Color.Tan
        Me.cmdToastCheeseBrown.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdToastCheeseBrown.ForeColor = System.Drawing.Color.Black
        Me.cmdToastCheeseBrown.Location = New System.Drawing.Point(8, 92)
        Me.cmdToastCheeseBrown.Name = "cmdToastCheeseBrown"
        Me.cmdToastCheeseBrown.Size = New System.Drawing.Size(75, 75)
        Me.cmdToastCheeseBrown.TabIndex = 10
        Me.cmdToastCheeseBrown.Text = "Τοστ με Κασέρι (Μαύρο Ψωμί)"
        '
        'cmdToastHamCheeseBrown
        '
        Me.cmdToastHamCheeseBrown.BackColor = System.Drawing.Color.IndianRed
        Me.cmdToastHamCheeseBrown.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdToastHamCheeseBrown.ForeColor = System.Drawing.Color.White
        Me.cmdToastHamCheeseBrown.Location = New System.Drawing.Point(92, 92)
        Me.cmdToastHamCheeseBrown.Name = "cmdToastHamCheeseBrown"
        Me.cmdToastHamCheeseBrown.Size = New System.Drawing.Size(75, 75)
        Me.cmdToastHamCheeseBrown.TabIndex = 9
        Me.cmdToastHamCheeseBrown.Text = "Ανάμεικτο (Μαύρο Ψωμί)"
        '
        'cmdToastChips
        '
        Me.cmdToastChips.BackColor = System.Drawing.Color.Tan
        Me.cmdToastChips.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdToastChips.ForeColor = System.Drawing.Color.White
        Me.cmdToastChips.Location = New System.Drawing.Point(176, 8)
        Me.cmdToastChips.Name = "cmdToastChips"
        Me.cmdToastChips.Size = New System.Drawing.Size(75, 75)
        Me.cmdToastChips.TabIndex = 8
        Me.cmdToastChips.Text = "Τοστ με Πατατάκια"
        '
        'cmdToastCheese
        '
        Me.cmdToastCheese.BackColor = System.Drawing.Color.NavajoWhite
        Me.cmdToastCheese.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdToastCheese.ForeColor = System.Drawing.Color.Black
        Me.cmdToastCheese.Location = New System.Drawing.Point(8, 8)
        Me.cmdToastCheese.Name = "cmdToastCheese"
        Me.cmdToastCheese.Size = New System.Drawing.Size(75, 75)
        Me.cmdToastCheese.TabIndex = 7
        Me.cmdToastCheese.Text = "Τοστ με Κασέρι"
        '
        'cmdToastHamCheese
        '
        Me.cmdToastHamCheese.BackColor = System.Drawing.Color.Salmon
        Me.cmdToastHamCheese.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdToastHamCheese.ForeColor = System.Drawing.Color.White
        Me.cmdToastHamCheese.Location = New System.Drawing.Point(92, 8)
        Me.cmdToastHamCheese.Name = "cmdToastHamCheese"
        Me.cmdToastHamCheese.Size = New System.Drawing.Size(75, 75)
        Me.cmdToastHamCheese.TabIndex = 6
        Me.cmdToastHamCheese.Text = "Ανάμεικτο"
        '
        'pnlDesserts
        '
        Me.pnlDesserts.BackColor = System.Drawing.Color.DarkGray
        Me.pnlDesserts.BackgroundImage = CType(resources.GetObject("pnlDesserts.BackgroundImage"), System.Drawing.Image)
        Me.pnlDesserts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDesserts.Controls.Add(Me.cmdIceCreamSpecial)
        Me.pnlDesserts.Controls.Add(Me.cmdDoughnut)
        Me.pnlDesserts.Controls.Add(Me.cmdIcecream)
        Me.pnlDesserts.Controls.Add(Me.cmdCroissant)
        Me.pnlDesserts.Controls.Add(Me.cmdCheeseCake)
        Me.pnlDesserts.Controls.Add(Me.cmdBlackForrest)
        Me.pnlDesserts.Controls.Add(Me.cmdCake)
        Me.pnlDesserts.Controls.Add(Me.cmdApplepie)
        Me.pnlDesserts.Location = New System.Drawing.Point(519, 39)
        Me.pnlDesserts.Name = "pnlDesserts"
        Me.pnlDesserts.Size = New System.Drawing.Size(345, 530)
        Me.pnlDesserts.TabIndex = 41
        '
        'cmdIceCreamSpecial
        '
        Me.cmdIceCreamSpecial.BackColor = System.Drawing.Color.White
        Me.cmdIceCreamSpecial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdIceCreamSpecial.ForeColor = System.Drawing.Color.Black
        Me.cmdIceCreamSpecial.Image = CType(resources.GetObject("cmdIceCreamSpecial.Image"), System.Drawing.Image)
        Me.cmdIceCreamSpecial.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdIceCreamSpecial.Location = New System.Drawing.Point(260, 92)
        Me.cmdIceCreamSpecial.Name = "cmdIceCreamSpecial"
        Me.cmdIceCreamSpecial.Size = New System.Drawing.Size(75, 75)
        Me.cmdIceCreamSpecial.TabIndex = 13
        Me.cmdIceCreamSpecial.Text = "Supreme"
        Me.cmdIceCreamSpecial.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdDoughnut
        '
        Me.cmdDoughnut.BackColor = System.Drawing.Color.Crimson
        Me.cmdDoughnut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdDoughnut.ForeColor = System.Drawing.Color.Black
        Me.cmdDoughnut.Image = CType(resources.GetObject("cmdDoughnut.Image"), System.Drawing.Image)
        Me.cmdDoughnut.Location = New System.Drawing.Point(92, 92)
        Me.cmdDoughnut.Name = "cmdDoughnut"
        Me.cmdDoughnut.Size = New System.Drawing.Size(75, 75)
        Me.cmdDoughnut.TabIndex = 12
        Me.cmdDoughnut.Text = "Doughnut"
        Me.cmdDoughnut.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdIcecream
        '
        Me.cmdIcecream.BackColor = System.Drawing.Color.White
        Me.cmdIcecream.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdIcecream.ForeColor = System.Drawing.Color.Black
        Me.cmdIcecream.Image = CType(resources.GetObject("cmdIcecream.Image"), System.Drawing.Image)
        Me.cmdIcecream.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdIcecream.Location = New System.Drawing.Point(176, 92)
        Me.cmdIcecream.Name = "cmdIcecream"
        Me.cmdIcecream.Size = New System.Drawing.Size(75, 75)
        Me.cmdIcecream.TabIndex = 11
        Me.cmdIcecream.Text = "Παγωτό"
        Me.cmdIcecream.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdCroissant
        '
        Me.cmdCroissant.BackColor = System.Drawing.Color.LimeGreen
        Me.cmdCroissant.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCroissant.ForeColor = System.Drawing.Color.Black
        Me.cmdCroissant.Image = CType(resources.GetObject("cmdCroissant.Image"), System.Drawing.Image)
        Me.cmdCroissant.Location = New System.Drawing.Point(8, 92)
        Me.cmdCroissant.Name = "cmdCroissant"
        Me.cmdCroissant.Size = New System.Drawing.Size(75, 75)
        Me.cmdCroissant.TabIndex = 10
        Me.cmdCroissant.Text = "Croissant"
        Me.cmdCroissant.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdCheeseCake
        '
        Me.cmdCheeseCake.BackColor = System.Drawing.Color.Gold
        Me.cmdCheeseCake.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCheeseCake.ForeColor = System.Drawing.Color.Black
        Me.cmdCheeseCake.Image = CType(resources.GetObject("cmdCheeseCake.Image"), System.Drawing.Image)
        Me.cmdCheeseCake.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdCheeseCake.Location = New System.Drawing.Point(260, 8)
        Me.cmdCheeseCake.Name = "cmdCheeseCake"
        Me.cmdCheeseCake.Size = New System.Drawing.Size(75, 75)
        Me.cmdCheeseCake.TabIndex = 9
        Me.cmdCheeseCake.Text = "Cheese Cake"
        Me.cmdCheeseCake.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdBlackForrest
        '
        Me.cmdBlackForrest.BackColor = System.Drawing.Color.Sienna
        Me.cmdBlackForrest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdBlackForrest.ForeColor = System.Drawing.Color.White
        Me.cmdBlackForrest.Image = CType(resources.GetObject("cmdBlackForrest.Image"), System.Drawing.Image)
        Me.cmdBlackForrest.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdBlackForrest.Location = New System.Drawing.Point(176, 8)
        Me.cmdBlackForrest.Name = "cmdBlackForrest"
        Me.cmdBlackForrest.Size = New System.Drawing.Size(75, 75)
        Me.cmdBlackForrest.TabIndex = 8
        Me.cmdBlackForrest.Text = "Black Forrest"
        Me.cmdBlackForrest.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdCake
        '
        Me.cmdCake.BackColor = System.Drawing.Color.RoyalBlue
        Me.cmdCake.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCake.ForeColor = System.Drawing.Color.White
        Me.cmdCake.Image = CType(resources.GetObject("cmdCake.Image"), System.Drawing.Image)
        Me.cmdCake.Location = New System.Drawing.Point(92, 8)
        Me.cmdCake.Name = "cmdCake"
        Me.cmdCake.Size = New System.Drawing.Size(75, 75)
        Me.cmdCake.TabIndex = 7
        Me.cmdCake.Text = "Κέϊκ"
        Me.cmdCake.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdApplepie
        '
        Me.cmdApplepie.BackColor = System.Drawing.Color.PeachPuff
        Me.cmdApplepie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdApplepie.ForeColor = System.Drawing.Color.Black
        Me.cmdApplepie.Image = CType(resources.GetObject("cmdApplepie.Image"), System.Drawing.Image)
        Me.cmdApplepie.Location = New System.Drawing.Point(8, 8)
        Me.cmdApplepie.Name = "cmdApplepie"
        Me.cmdApplepie.Size = New System.Drawing.Size(75, 75)
        Me.cmdApplepie.TabIndex = 6
        Me.cmdApplepie.Text = "Μηλόπιτα"
        Me.cmdApplepie.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'pnlEnergyDrinks
        '
        Me.pnlEnergyDrinks.BackColor = System.Drawing.Color.DarkGray
        Me.pnlEnergyDrinks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEnergyDrinks.Controls.Add(Me.cmdLucosade)
        Me.pnlEnergyDrinks.Controls.Add(Me.cmdRedBull)
        Me.pnlEnergyDrinks.Location = New System.Drawing.Point(519, 39)
        Me.pnlEnergyDrinks.Name = "pnlEnergyDrinks"
        Me.pnlEnergyDrinks.Size = New System.Drawing.Size(345, 530)
        Me.pnlEnergyDrinks.TabIndex = 42
        '
        'cmdLucosade
        '
        Me.cmdLucosade.BackColor = System.Drawing.Color.IndianRed
        Me.cmdLucosade.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdLucosade.ForeColor = System.Drawing.Color.White
        Me.cmdLucosade.Location = New System.Drawing.Point(92, 8)
        Me.cmdLucosade.Name = "cmdLucosade"
        Me.cmdLucosade.Size = New System.Drawing.Size(75, 75)
        Me.cmdLucosade.TabIndex = 7
        Me.cmdLucosade.Text = "Lucosade"
        '
        'cmdRedBull
        '
        Me.cmdRedBull.BackColor = System.Drawing.Color.White
        Me.cmdRedBull.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdRedBull.ForeColor = System.Drawing.Color.White
        Me.cmdRedBull.Image = CType(resources.GetObject("cmdRedBull.Image"), System.Drawing.Image)
        Me.cmdRedBull.Location = New System.Drawing.Point(8, 8)
        Me.cmdRedBull.Name = "cmdRedBull"
        Me.cmdRedBull.Size = New System.Drawing.Size(75, 75)
        Me.cmdRedBull.TabIndex = 6
        '
        'frmOrder
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.pnlNoItems)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblSum)
        Me.Controls.Add(Me.lblEuroSign)
        Me.Controls.Add(Me.lsvCurrent)
        Me.Controls.Add(Me.cmdSelfServe)
        Me.Controls.Add(Me.cmdSubQuantity)
        Me.Controls.Add(Me.cmdPrintCheck)
        Me.Controls.Add(Me.cmdSend)
        Me.Controls.Add(Me.cmdBackToMainMenu)
        Me.Controls.Add(Me.pnlCategories)
        Me.Controls.Add(Me.pnlAlcohol)
        Me.Controls.Add(Me.pnlBeverages)
        Me.Controls.Add(Me.pnlSnacks)
        Me.Controls.Add(Me.pnlSoftdrinks)
        Me.Controls.Add(Me.cmdCategoryBack)
        Me.Controls.Add(Me.pnlWater)
        Me.Controls.Add(Me.pnlSoda)
        Me.Controls.Add(Me.pnlBottles)
        Me.Controls.Add(Me.pnlCans)
        Me.Controls.Add(Me.pnlColdDishes)
        Me.Controls.Add(Me.pnlMilkShake)
        Me.Controls.Add(Me.pnlChoco)
        Me.Controls.Add(Me.pnlTea)
        Me.Controls.Add(Me.pnlJuices)
        Me.Controls.Add(Me.pnlCoffees)
        Me.Controls.Add(Me.pnlCocktails)
        Me.Controls.Add(Me.pnlDesserts)
        Me.Controls.Add(Me.pnlToast)
        Me.Controls.Add(Me.pnlBeers)
        Me.Controls.Add(Me.pnlDrinks)
        Me.Controls.Add(Me.pnlBurgers)
        Me.Controls.Add(Me.pnlWines)
        Me.Controls.Add(Me.pnlAlcoholSoftDrinks)
        Me.Controls.Add(Me.pnlEnergyDrinks)
        Me.Controls.Add(Me.pnlHotDishes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmOrder"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlCategories.ResumeLayout(False)
        Me.pnlAlcohol.ResumeLayout(False)
        Me.pnlBeverages.ResumeLayout(False)
        Me.pnlSnacks.ResumeLayout(False)
        Me.pnlSoftdrinks.ResumeLayout(False)
        Me.pnlBeers.ResumeLayout(False)
        Me.pnlDrinks.ResumeLayout(False)
        Me.pnlCocktails.ResumeLayout(False)
        Me.pnlAlcoholSoftDrinks.ResumeLayout(False)
        Me.pnlWines.ResumeLayout(False)
        Me.pnlCoffees.ResumeLayout(False)
        Me.pnlColdDishes.ResumeLayout(False)
        Me.pnlJuices.ResumeLayout(False)
        Me.pnlTea.ResumeLayout(False)
        Me.pnlChoco.ResumeLayout(False)
        Me.pnlMilkShake.ResumeLayout(False)
        Me.pnlWater.ResumeLayout(False)
        Me.pnlSoda.ResumeLayout(False)
        Me.pnlBottles.ResumeLayout(False)
        Me.pnlCans.ResumeLayout(False)
        Me.pnlHotDishes.ResumeLayout(False)
        Me.pnlBurgers.ResumeLayout(False)
        Me.pnlToast.ResumeLayout(False)
        Me.pnlDesserts.ResumeLayout(False)
        Me.pnlEnergyDrinks.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Reinitiallizes some attributes of the class
    Private Sub initiallizeTable()
        ' Loads the orders send of this table
        Dim i As Integer
        For i = 0 To orderOfTable(tableNum).getNumberOfItems - 1
            lsvCurrent.Items.Add(orderOfTable(tableNum).removeLastFromList)
        Next
        'The label showing the bill is updated
        total = orderOfTable(tableNum).getTableBill
        lblTotal.Text = total.ToString
        'Gives the cmdcmdBackToMainMenu the default text and color
        cmdBackToMainMenu.Text = "ΕΠΙΣΤΡΟΦΗ"
        cmdBackToMainMenu.BackColor = Color.Chocolate
        'These buttons are disabled until an order is given
        cmdSelfServe.Enabled = False
        cmdSend.Enabled = False
        hasGivenOrder = False
        If lsvCurrent.Items.Count = 0 Then
            cmdPrintCheck.Enabled = False
        Else
            cmdPrintCheck.Enabled = True
        End If
    End Sub

    Public Sub loadOrderForTable(ByRef table As Button, ByVal _tableNum As Integer, ByRef cashiersCount As Integer)
        If Not (cashiersCount = 1 Or cashiersCount = 2) Then
            MsgBox("Δεν υπάρχουν ανοικτά ταμεία!")
            Exit Sub
        End If
        ' Clear all orders from the list
        lsvCurrent.Items.Clear()
        ' Sets the active table
        activeTable = table
        ' Sets the active table number - used as an index for the orderSheets array
        tableNum = _tableNum
        'Updates data that are attached to the "table"
        initiallizeTable()
        ' Shows the order frame
        Me.Show()
    End Sub

    Private Sub increaseTotal(ByVal amount As PrecisionOfTwo)
        ' Increases the total "amount" of the table by the term amount
        total.add(amount)
        ' Shows the new total "amount" for this table
        lblTotal.Text = total.ToString
    End Sub

    Private Sub decreaseTotal(ByVal amount As PrecisionOfTwo)
        ' Decreases the total "amount" of the table by the term amount
        total.subt(amount)
        ' Shows the new total "amount" for this table
        lblTotal.Text = total.ToString
    End Sub

    Private Sub increaseQuantity(ByRef position)
        'Increases the quantity of a certain item - the one indicated by the variable position
        Dim quantity As String
        quantity = lsvCurrent.Items(position).SubItems(1).Text + 1
        lsvCurrent.Items(position).SubItems(1).Text = quantity
    End Sub

    Private Sub checkIfZeroQuantity(ByRef quantity As Integer)
        If quantity > 0 Then
            lsvCurrent.FocusedItem.SubItems(1).Text = quantity
        Else
            ' If quantity equals zero then the item is removed from the order list
            lsvCurrent.Items.Remove(lsvCurrent.FocusedItem)
            ' ... and the Add and Sub buttons are disabled
            cmdSubQuantity.Enabled = False
        End If
    End Sub

    Private Sub cmdSubQuantity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSubQuantity.Click
        ' Used to decrease the quantity of the selected item
        Dim quantity As Integer
        quantity = lsvCurrent.FocusedItem.SubItems(1).Text - 1
        Dim itemsPrice As PrecisionOfTwo
        itemsPrice = itemsPrice.stringToPrecisionOfTwo(lsvCurrent.FocusedItem.SubItems(2).Text)
        ' Decreases the total "amount" by the price of the item
        decreaseTotal(itemsPrice)
        checkIfZeroQuantity(quantity)
    End Sub

    Private Sub lsvcurrent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lsvCurrent.Click
        ' When the user clicks on an item the Add and Sub buttons are enabled, so that he can use them to increase or decrease the quantity respectively
        If lsvCurrent.FocusedItem.Index > orderOfTable(tableNum).handleListIndex - 1 Then
            cmdSubQuantity.Enabled = True
        End If
    End Sub

    Private Sub cmdPrintCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintCheck.Click
        lsvCurrent.Items.Clear()
        If tableNum < 16 Then
            FileHandler.createReceipt(cashRegisters.Item(0), tableNum, orderOfTable(tableNum), lblTotal.Text)
            cashRegisters.Item(0).handleMoney = total
        Else
            FileHandler.createReceipt(cashRegisters.Item(1), tableNum, orderOfTable(tableNum), lblTotal.Text)
            cashRegisters.Item(1).handleMoney = total
        End If
        Dim i As Integer
        For i = 0 To orderOfTable(tableNum).getNumberOfItems - 1
            orderOfTable(tableNum).removeLastFromList()
        Next
        orderOfTable(tableNum).clearBill()
        lblTotal.Text = orderOfTable(tableNum).getBillAsString
        cmdPrintCheck.Enabled = False
    End Sub

    Private Sub saveOrders(ByVal elementsToSave As Integer)
        If elementsToSave > 0 Then
            ' Saves the orders of this table in order to process them again in the future
            Dim i As Integer
            For i = 0 To elementsToSave - 1
                orderOfTable(tableNum).addToList(lsvCurrent.Items(i))
            Next
        End If
    End Sub

    Private Sub cmdSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSend.Click
        cmdBackToMainMenu.Text = "ΕΠΙΣΤΡΟΦΗ"
        cmdBackToMainMenu.BackColor = Color.Chocolate
        cmdSend.Enabled = False
        cmdSelfServe.Enabled = False
        cmdPrintCheck.Enabled = True
        hasGivenOrder = True
        orderOfTable(tableNum).handleListIndex = lsvCurrent.Items.Count
        saveOrders(orderOfTable(tableNum).handleListIndex)
        orderOfTable(tableNum).setBillEqualTo(total)
    End Sub

    Private Sub cmdBackToMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBackToMainMenu.Click
        ' Checks if changing the table color is necessary - an active table is MediumSeaGreen and an inactive is DarkGray
        If lsvCurrent.Items.Count = 0 Then
            activeTable.BackColor = BackColor.DarkGray
        Else
            activeTable.BackColor = BackColor.MediumSeaGreen
        End If

        If cmdBackToMainMenu.Text = "ΑΚΥΡΟ" Then
            saveOrders(orderOfTable(tableNum).handleListIndex)
        Else
            If Not hasGivenOrder Then
                saveOrders(orderOfTable(tableNum).handleListIndex)
            End If
        End If
        ' Resets the items category panel
        resetCategoryPanels()
        ' Resets the total order amount
        lblTotal.Text = "0,00"

        hasGivenOrder = False
        ' Hides the frame
        Me.Hide()
    End Sub

    Private Function calculateTax()
        Dim fpa As PrecisionOfTwo
        Dim onePlusFpa As PrecisionOfTwo
        Dim price As PrecisionOfTwo
        Dim finalPrice As PrecisionOfTwo = finalPrice.stringToPrecisionOfTwo(lsvCurrent.FocusedItem.SubItems(2).Text)
        decreaseTotal(finalPrice)
        Dim hasAlchohol As Boolean = CBool(lsvCurrent.FocusedItem.SubItems(3).Text)
        If hasAlchohol Then
            fpa = New PrecisionOfTwo(0.19)
            onePlusFpa = New PrecisionOfTwo(1 + 0.19)
        Else
            fpa = New PrecisionOfTwo(0.9)
            onePlusFpa = New PrecisionOfTwo(1 + 0.9)
        End If
        price = finalPrice.div(onePlusFpa)
        Dim tax As PrecisionOfTwo = price.mul(fpa)
        Return tax
    End Function

    Private Sub addToList(ByRef item As String, ByRef quantity As Integer, ByRef price As String, ByRef hasAlchohol As Boolean)
        Dim data As New ListViewItem(item)
        data.SubItems.Add(quantity)
        data.SubItems.Add(price)
        data.SubItems.Add(hasAlchohol)
        lsvCurrent.Items.Add(data)
    End Sub

    Private Sub cmdSelfServe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelfServe.Click
        If lsvCurrent.FocusedItem Is Nothing Then
            MsgBox("Δεν έχετε επιλέξει κάποιο προϊόν!")
        Else
            If lsvCurrent.FocusedItem.SubItems(1).Text.Equals("-1") Then
                MsgBox("Η λειτουργία για το επιλεγμένο είδος έχει ήδη εκτελεστεί!")
            Else
                If lsvCurrent.FocusedItem.Index > orderOfTable(tableNum).handleListIndex - 1 Then
                    Dim tax As PrecisionOfTwo
                    tax = calculateTax()
                    increaseTotal(tax)
                    addToList(lsvCurrent.FocusedItem.SubItems(0).Text, -1, tax.ToString, lsvCurrent.FocusedItem.SubItems(3).Text)
                    ' Used to decrease the quantity of the selected item
                    Dim quantity As Integer
                    quantity = lsvCurrent.FocusedItem.SubItems(1).Text - 1
                    ' Decreases the total "amount" by the tax of the item
                    checkIfZeroQuantity(quantity)
                Else
                    MsgBox("Δεν επιτέπεται το κέρασμα είδους που έχει αποσταλλεί.")
                End If
            End If
        End If
    End Sub

    Private Sub resetCategoryPanels()
        ' This panel is the active one-its the only one the user can see and use
        pnlCategories.BringToFront()
        ' The button is hidden from the user-he can't use what he can't see
        cmdCategoryBack.SendToBack()
        ' Resets Add and Sub buttons
        cmdSubQuantity.Enabled = False
        ' Resets the item panel
        pnlNoItems.BringToFront()
    End Sub

    Private Sub cmdBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCategoryBack.Click
        ' Reinitiallize the category panels
        resetCategoryPanels()
    End Sub

    Private Sub cmdAlcohol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAlcohol.Click
        ' The alchohol panel becames the one the user sees 
        pnlAlcohol.Visible = True
        pnlAlcohol.BringToFront()
        ' The button is shown to the user, so that he may use it
        cmdCategoryBack.BringToFront()
    End Sub

    Private Sub cmdBeverages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBeverages.Click
        ' The alchohol panel becames the one the user sees
        pnlBeverages.Visible = True
        pnlBeverages.BringToFront()
        ' The button is shown to the user, so that he may use it
        cmdCategoryBack.BringToFront()
    End Sub

    Private Sub cmdSnacks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSnacks.Click
        ' The snacks panel becames the one the user sees
        pnlSnacks.Visible = True
        pnlSnacks.BringToFront()
        ' The button is shown to the user, so that he may use it
        cmdCategoryBack.BringToFront()
    End Sub

    Private Sub cmdEnergyDrinks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnergyDrinks.Click
        ' The energy drinks panel becames the one the user sees
        pnlEnergyDrinks.Visible = True
        pnlEnergyDrinks.BringToFront()
        ' The button is shown to the user, so that he may use it
        cmdCategoryBack.BringToFront()
    End Sub

    Private Sub cmdSoftDrinks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSoftdrinks.Click
        ' The softdrinks panel becames the one the user sees
        pnlSoftdrinks.Visible = True
        pnlSoftdrinks.BringToFront()
        ' The button is shown to the user, so that he may use it
        cmdCategoryBack.BringToFront()
    End Sub

    Private Sub cmdBeers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBeers.Click
        ' The available beers appear on the items panel
        pnlBeers.Visible = True
        pnlBeers.BringToFront()
    End Sub

    Private Sub cmdCoctails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCoctails.Click
        ' The available cocktails appear on the items panel
        pnlCocktails.Visible = True
        pnlCocktails.BringToFront()
    End Sub

    Private Sub cmdWine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWine.Click
        ' The available wines appear on the items panel
        pnlWines.Visible = True
        pnlWines.BringToFront()
    End Sub

    Private Sub cmdDrinks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDrinks.Click
        ' The available drinks appear on the items panel
        pnlDrinks.Visible = True
        pnlDrinks.BringToFront()
    End Sub

    Private Sub cmdAlcSoftDrinks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAlcSoftdrinks.Click
        ' The available alcohol softdrinks appear on the items panel
        pnlAlcoholSoftDrinks.Visible = True
        pnlAlcoholSoftDrinks.BringToFront()
    End Sub

    Private Sub cmdCoffees_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCoffees.Click
        ' The available coffees appear on the items panel
        pnlCoffees.Visible = True
        pnlCoffees.BringToFront()
    End Sub

    Private Sub cmdJuices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdJuices.Click
        ' The available juices appear on the items panel
        pnlJuices.Visible = True
        pnlJuices.BringToFront()
    End Sub

    Private Sub cmdTea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTea.Click
        ' The available tea appear on the items panel
        pnlTea.Visible = True
        pnlTea.BringToFront()
    End Sub

    Private Sub cmdChoco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChoco.Click
        ' The available choco appear on the items panel
        pnlChoco.Visible = True
        pnlChoco.BringToFront()
    End Sub

    Private Sub cmdMilkShake_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMilkShake.Click
        ' The available milkshake appear on the items panel
        pnlMilkShake.Visible = True
        pnlMilkShake.BringToFront()
    End Sub

    Private Sub cmdColdDishes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdColdDishes.Click
        ' The available cold dishes appear on the items panel
        pnlColdDishes.Visible = True
        pnlColdDishes.BringToFront()
    End Sub

    Private Sub cmdHotDishes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHotDishes.Click
        ' The available hot dishes appear on the items panel
        pnlHotDishes.Visible = True
        pnlHotDishes.BringToFront()
    End Sub

    Private Sub cmdBurgers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBurgers.Click
        ' The available burgers appear on the items panel
        pnlBurgers.Visible = True
        pnlBurgers.BringToFront()
    End Sub

    Private Sub cmdToast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToast.Click
        ' The available toast appear on the items panel
        pnlToast.Visible = True
        pnlToast.BringToFront()
    End Sub

    Private Sub cmdDesserts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDesserts.Click
        ' The available desserts appear on the items panel
        pnlDesserts.Visible = True
        pnlDesserts.BringToFront()
    End Sub

    Private Sub cmdCans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCans.Click
        ' The available cans appear on the items panel
        pnlCans.Visible = True
        pnlCans.BringToFront()
    End Sub

    Private Sub cmdBottles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBottles.Click
        ' The available bottles appear on the items panel
        pnlBottles.Visible = True
        pnlBottles.BringToFront()
    End Sub

    Private Sub cmdSoda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSoda.Click
        ' The available soda appear on the items panel
        pnlSoda.Visible = True
        pnlSoda.BringToFront()
    End Sub

    Private Sub cmdWater_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWater.Click
        ' The available water appear on the items panel
        pnlWater.Visible = True
        pnlWater.BringToFront()
    End Sub

    Private Sub takeOrder(ByVal price As Double, ByRef name As String, ByRef hasAlchohol As Boolean)
        Dim itemsPrice As New PrecisionOfTwo(price)
        Dim isInList As Boolean = False
        Dim inPosition As Integer
        If orderOfTable(tableNum).handleListIndex > -1 Then
            Dim i As Integer
            For i = orderOfTable(tableNum).handleListIndex To lsvCurrent.Items.Count - 1
                If name.Equals(lsvCurrent.Items(i).SubItems(0).Text) Then
                    isInList = True
                    inPosition = i
                End If
            Next
        End If
        If isInList Then
            If lsvCurrent.Items(inPosition).SubItems(1).Text.Equals("-1") Then
                addToList(name, 1, itemsPrice.ToString, hasAlchohol)
            Else
                increaseQuantity(inPosition)
            End If
        Else
            addToList(name, 1, itemsPrice.ToString, hasAlchohol)
        End If
        increaseTotal(itemsPrice)
        cmdSelfServe.Enabled = True
        cmdSend.Enabled = True
        cmdPrintCheck.Enabled = False
        cmdBackToMainMenu.Text = "ΑΚΥΡΟ"
        cmdBackToMainMenu.BackColor = Color.IndianRed
    End Sub

    Private Sub cmdSmirnoffIce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSmirnoffIce.Click
        takeOrder(4.5, "Smirnoff Ice", True)
    End Sub

    Private Sub cmdBudweiser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBudweiser.Click
        takeOrder(4.5, "Budweiser", True)
    End Sub

    Private Sub cmdBud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBud.Click
        takeOrder(4.5, "Bud", True)
    End Sub

    Private Sub cmdBudLight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBudLight.Click
        takeOrder(4.5, "Bud Light", True)
    End Sub

    Private Sub cmdGoorsLight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGoorsLight.Click
        takeOrder(4.5, "Goors Light", True)
    End Sub

    Private Sub cmdCarlsberg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCarlsberg.Click
        takeOrder(3.5, "Carlsberg", True)
    End Sub

    Private Sub cmdHeineken_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHeineken.Click
        takeOrder(3.5, "Heineken", True)
    End Sub

    Private Sub cmdMillerLite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMillerLite.Click
        takeOrder(4.5, "Miller Lite", True)
    End Sub

    Private Sub cmdCoronaExtra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCoronaExtra.Click
        takeOrder(4.5, "Corona Extra", True)
    End Sub

    Private Sub cmdAmstel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAmstel.Click
        takeOrder(3.5, "Amstel", True)
    End Sub

    Private Sub cmdGordonsSpace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGordonsSpace.Click
        takeOrder(4.5, "Gordons Space", True)
    End Sub

    Private Sub cmdBacardiBreezer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBacardiBreezer.Click
        takeOrder(4.5, "Bacardi Breezer", True)
    End Sub

    Private Sub cmdMargarita_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMargarita.Click
        takeOrder(6.0, "Margarita", True)
    End Sub

    Private Sub cmdWhiteRussian_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWhiteRussian.Click
        takeOrder(6.0, "White Russian", True)
    End Sub

    Private Sub cmdB52_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdB52.Click
        takeOrder(6.0, "B-52", True)
    End Sub

    Private Sub cmdTequillaSunrise_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTequillaSunrise.Click
        takeOrder(6.0, "Tequilla Sunrise", True)
    End Sub

    Private Sub cmdVariousCocktails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVariousCocktails.Click
        takeOrder(6.0, "Cocktail", True)

    End Sub

    Private Sub cmdCardu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCardu.Click
        takeOrder(7.0, "Cardu", True)
    End Sub

    Private Sub cmdChivasRegal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChivasRegal.Click
        takeOrder(6.0, "Chivas Regal", True)
    End Sub

    Private Sub cmdJimBeam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdJimBeam.Click
        takeOrder(5.0, "Jim Beam", True)
    End Sub

    Private Sub cmdGlenfiddich_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGlenfiddich.Click
        takeOrder(7.0, "Glenfiddich", True)
    End Sub

    Private Sub cmdSmirnoffVodka_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSmirnoffVodka.Click
        takeOrder(5.0, "Smirnoff Vodka", True)
    End Sub

    Private Sub cmdAbsolutVodka_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbsolutVodka.Click
        takeOrder(5.0, "Absolut Vodka", True)
    End Sub

    Private Sub cmdRedBull_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRedBull.Click
        takeOrder(4.5, "Red Bull", False)
    End Sub

    Private Sub cmdLucosade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLucosade.Click
        takeOrder(4.5, "Lucosade", False)
    End Sub

    Private Sub cmdYdor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdYdor.Click
        takeOrder(1.0, "Ύδωρ Σουρωτής", False)
    End Sub

    Private Sub cmdWater500_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWater500.Click
        takeOrder(0.5, "Εμφιαλωμένο 500ml", False)
    End Sub

    Private Sub cmdWater1000_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWater1000.Click
        takeOrder(1.0, "Εμφιαλωμένο 1000ml", False)

    End Sub

    Private Sub cmdSourotiOrange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSourotiOrange.Click
        takeOrder(2.5, "Σουρωτή Πορτοκάλι", False)

    End Sub

    Private Sub cmdSouroti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSouroti.Click
        takeOrder(2.5, "Σουρωτή", False)

    End Sub

    Private Sub cmdTuborg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTuborg.Click
        takeOrder(2.5, "Tuborg", False)

    End Sub

    Private Sub cmd7upbottle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd7upbottle.Click
        takeOrder(3.0, "7-Up 500ml", False)

    End Sub

    Private Sub cmdSpriteBottle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSpriteBottle.Click
        takeOrder(3.0, "Sprite 500ml", False)

    End Sub

    Private Sub cmdDrPepperBottle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDrPepperBottle.Click
        takeOrder(3.0, "Dr. Pepper 500ml", False)

    End Sub

    Private Sub cmdPepsiBottle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPepsiBottle.Click
        takeOrder(3.0, "Pepsi 500ml", False)

    End Sub

    Private Sub cmdCocaBottle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCocaBottle.Click
        takeOrder(3.0, "Coca Cola 500ml", False)

    End Sub

    Private Sub cmdFantaBottle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFantaBottle.Click
        takeOrder(3.0, "Fanta 500ml", False)

    End Sub

    Private Sub cmdCocaCola_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCocaCola.Click
        takeOrder(2.5, "Coca Cola 330ml", False)

    End Sub

    Private Sub cmdPepsi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPepsi.Click
        takeOrder(2.5, "Pepsi 330ml", False)

    End Sub

    Private Sub cmd7up_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd7up.Click
        takeOrder(2.5, "7-Up 330ml", False)

    End Sub

    Private Sub cmdFanta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFanta.Click
        takeOrder(2.5, "Fanta 330ml", False)

    End Sub

    Private Sub cmdSprite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSprite.Click
        takeOrder(2.5, "Sprite 330ml", False)

    End Sub

    Private Sub cmdDrPepper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDrPepper.Click
        takeOrder(2.5, "Dr. Pepper 330ml", False)

    End Sub

    Private Sub cmdSalads_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalads.Click
        takeOrder(3.5, "Σαλάτα", False)

    End Sub

    Private Sub cmdSandwich_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSandwich.Click
        takeOrder(3.0, "Κρύο Σάντουϊτς", False)

    End Sub

    Private Sub cmdMShake_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMShake.Click
        takeOrder(3.5, "Milk Shake", False)

    End Sub

    Private Sub cmdHotChoco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHotChoco.Click
        takeOrder(2.7, "Ζεστή Σοκολάτα", False)

    End Sub

    Private Sub cmdColdChoco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdColdChoco.Click
        takeOrder(2.7, "Κρύα Σοκολάτα", False)

    End Sub

    Private Sub cmdLipton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLipton.Click
        takeOrder(2.7, "Lipton Ice Tea", False)

    End Sub

    Private Sub cmdIceTea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIceTea.Click
        takeOrder(2.7, "Ice Tea", False)

    End Sub

    Private Sub cmdHotTea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHotTea.Click
        takeOrder(2.5, "Ζεστό Τσάϊ", False)

    End Sub

    Private Sub cmdOrange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOrange.Click
        takeOrder(2.7, "Χύμός Πορτοκάλι", False)

    End Sub

    Private Sub cmdPeach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPeach.Click
        takeOrder(2.7, "Χυμός Ροδάκινο", False)

    End Sub

    Private Sub cmdBanana_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBanana.Click
        takeOrder(2.7, "Χυμός Μπανάνα", False)

    End Sub

    Private Sub cmdCherry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCherry.Click
        takeOrder(2.7, "Χυμός Βύσσινο", False)

    End Sub

    Private Sub cmdApricot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApricot.Click
        takeOrder(2.7, "Χυμός Βερίκοκο", False)

    End Sub

    Private Sub cmdMixed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMixed.Click
        takeOrder(2.7, "Χυμός Ανάμικτος", False)

    End Sub

    Private Sub cmdNes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNes.Click
        takeOrder(2.5, "Nes Cafe", False)

    End Sub

    Private Sub cmdFrappe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFrappe.Click
        takeOrder(2.5, "Φραπέ", False)

    End Sub

    Private Sub cmdApplepie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApplepie.Click
        takeOrder(3.5, "Μηλόπιτα", False)

    End Sub

    Private Sub cmdCake_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCake.Click
        takeOrder(3.5, "Κέϊκ", False)

    End Sub

    Private Sub cmdBlackForrest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBlackForrest.Click
        takeOrder(3.5, "Black Forrest", False)

    End Sub

    Private Sub cmdCheeseCake_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheeseCake.Click
        takeOrder(3.5, "Cheese Cake", False)

    End Sub

    Private Sub cmdCroissant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCroissant.Click
        takeOrder(2.0, "Croissant", False)

    End Sub

    Private Sub cmdDoughnut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDoughnut.Click
        takeOrder(2.0, "Doughnut", False)

    End Sub

    Private Sub cmdIcecream_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIcecream.Click
        takeOrder(3.5, "Παγωτό", False)

    End Sub

    Private Sub cmdIceCreamSpecial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIceCreamSpecial.Click
        takeOrder(4.5, "Παγωτό Supreme", False)

    End Sub

    Private Sub cmdToastCheese_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToastCheese.Click
        takeOrder(2.5, "Τοστ με κασέρι", False)

    End Sub

    Private Sub cmdToastHamCheese_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToastHamCheese.Click
        takeOrder(2.5, "Τοστ Ανάμεικτο", False)

    End Sub

    Private Sub cmdToastChips_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToastChips.Click
        takeOrder(3.0, "Τοστ με πατατάκια", False)

    End Sub

    Private Sub cmdToastCheeseBrown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToastCheeseBrown.Click
        takeOrder(2.5, "Τοστ με Κασέρι ΜΨ", False)
    End Sub

    Private Sub cmdToastHamCheeseBrown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToastHamCheeseBrown.Click
        takeOrder(2.5, "Τοστ Ανάμεικτο ΜΨ", False)

    End Sub

    Private Sub cmdToastChipsBrown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToastChipsBrown.Click
        takeOrder(3.0, "Τοστ με Πατατάκια ΜΨ", False)

    End Sub

    Private Sub cmdGordons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGordons.Click
        takeOrder(5.0, "Gordon's Gin", True)

    End Sub

    Private Sub cmdJohnnieWalker_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdJohnnieWalker.Click
        takeOrder(5.0, "Johnnie Walker", True)

    End Sub

    Private Sub cmdJackDaniels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdJackDaniels.Click
        takeOrder(6.0, "Jack Daniels", True)

    End Sub

    Private Sub cmdHumBurger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHumBurger.Click
        takeOrder(2.5, "Humburger", False)

    End Sub

    Private Sub cmdCheeseBurger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheeseBurger.Click
        takeOrder(2.7, "Cheeseburger", False)

    End Sub

    Private Sub cmdDoubleBurger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDoubleBurger.Click
        takeOrder(3.0, "Double burger", False)

    End Sub

    Private Sub cmdBurgerGalore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBurgerGalore.Click
        takeOrder(3.5, "Burger Galore", False)

    End Sub

    Private Sub cmdHotDog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHotDog.Click
        takeOrder(2.7, "Hot Dog", False)

    End Sub

    Private Sub cmdOvenPotato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOvenPotato.Click
        takeOrder(2.7, "Πατάτα Φούρνου", False)

    End Sub

    Private Sub cmdEggs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEggs.Click
        takeOrder(2.5, "Ομελέτα", False)

    End Sub

    Private Sub cmdFrenchFries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFrenchFries.Click
        takeOrder(2.0, "Τηγανητές Πατάτες", False)

    End Sub

    Private Sub cmdPizza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPizza.Click
        takeOrder(2.5, "Pizza", False)

    End Sub

    Private Sub cmdSteak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSteak.Click
        takeOrder(6.0, "Μπριζόλα Μερ.", False)

    End Sub

    Private Sub cmdSteak2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSteak2.Click
        takeOrder(6.0, "Μπιφτέκι με πατάτες", False)

    End Sub

    Private Sub cmdBoutariRed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBoutariRed.Click
        takeOrder(3.0, "Μπουτάρι Κόκκινο Ποτ.", False)

    End Sub

    Private Sub cmdBoutariWhite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBoutariWhite.Click
        takeOrder(3.0, "Μπουτάρι Λευκό Ποτ.", False)

    End Sub

    Private Sub cmdTsantaliRed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTsantaliRed.Click
        takeOrder(3.0, "Τσάνταλι Κόκκινο Ποτ.", False)

    End Sub

    Private Sub cmdTsantaliWhite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTsantaliWhite.Click
        takeOrder(3.0, "Τσάνταλι Λευκό Ποτ.", False)

    End Sub

    Private Sub pnlNoItems_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlNoItems.Paint

    End Sub
End Class
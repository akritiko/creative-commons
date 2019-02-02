Public Interface IResource

    Event ImmigrationRequest(ByVal O As PCB)
    Sub Feed(ByVal PCB As PCB)
    ReadOnly Property Nop() As Boolean
    Function GetImmigrant() As PCB
    Sub Execute()


End Interface
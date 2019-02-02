class TripleNode
{
private:
	int _Value;
	TripleNode * _Left;
	TripleNode * _Right;
	TripleNode * _Father;
public:
	TripleNode(int VALUE, TripleNode * LEFT, TripleNode * RIGHT, TripleNode * Father);

	int getValue();
	TripleNode * getLeft();
	TripleNode * getRight();
	TripleNode * getFather();

	void setValue(int NewVal);
	void setLeft(TripleNode * Redirect);
	void setRight(TripleNode * Redirect);
	void setFather(TripleNode * Redirect);
};


// Ο δημιουργός
TripleNode::TripleNode(int VALUE, TripleNode * LEFT, TripleNode * RIGHT, TripleNode * Father)
{
	_Value = VALUE;
	_Right = RIGHT;
	_Left = LEFT;
	_Father = Father;
}



int TripleNode::getValue()
{
	return _Value;
}

TripleNode * TripleNode::getFather()
{
	return _Father;
}

TripleNode * TripleNode::getRight()
{
	return _Right;
}

TripleNode * TripleNode::getLeft()
{
	return _Left;
}



void TripleNode::setValue(int NewVal)
{
	_Value = NewVal;
}

void TripleNode::setFather(TripleNode * Redirect)
{
	_Father = Redirect;
}

void TripleNode::setLeft(TripleNode * Redirect)
{
	_Left = Redirect;
}

void TripleNode::setRight(TripleNode * Redirect)
{
	_Right = Redirect;
}

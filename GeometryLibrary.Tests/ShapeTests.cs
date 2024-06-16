namespace GeometryLibrary.Tests
{
    [TestFixture]
    public class ShapeTests
    {
        [Test]
        public void CircleAreaTest()
        {
            var circle = new Circle(5);
            Assert.That(circle.GetArea(), Is.EqualTo(Math.PI * 25).Within(1e-10));
        }

        [Test]
        public void TriangleAreaTest()
        {
            var triangle = new Triangle(3, 4, 5);
            double p = (3 + 4 + 5) / 2;
            double expectedArea = Math.Sqrt(p * (p - 3) * (p - 4) * (p - 5));
            Assert.That(triangle.GetArea(), Is.EqualTo(expectedArea).Within(1e-10));
        }

        [Test]
        public void RightTriangleTest()
        {
            var triangle = new Triangle(3, 4, 5);
            Assert.IsTrue(triangle.IsRightTriangle());
        }

        [Test]
        public void NotRightTriangleTest()
        {
            var triangle = new Triangle(3, 4, 6);
            Assert.IsFalse(triangle.IsRightTriangle());
        }

        [Test]
        public void ShapeFactoryCircleTest()
        {
            IAreaCalculable shape = ShapeFactory.CreateShape("circle", 5);
            Assert.IsInstanceOf<Circle>(shape);
            Assert.That(shape.GetArea(), Is.EqualTo(Math.PI * 25).Within(1e-10));
        }

        [Test]
        public void ShapeFactoryTriangleTest()
        {
            IAreaCalculable shape = ShapeFactory.CreateShape("triangle", 3, 4, 5);
            Assert.IsInstanceOf<Triangle>(shape);
            Assert.That(shape.GetArea(), Is.EqualTo(6).Within(1e-10));
        }

        [Test]
        public void ShapeFactoryInvalidShapeTest()
        {
            Assert.Throws<ArgumentException>(() => ShapeFactory.CreateShape("invalid", 1));
        }
    }
}

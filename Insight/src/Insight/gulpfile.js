//todo: fix gulp config
var gulp = require('gulp');
var uglify = require('gulp-uglify');

gulp.task('compress', function () {
    gulp.src('Scripts/**/*.js')
      .pipe(uglify())
      .pipe(gulp.dest('wwwroot'))
});

gulp.task('watch', function () {
    gulp.watch('Scripts/**/*.js', ['compress']);
});
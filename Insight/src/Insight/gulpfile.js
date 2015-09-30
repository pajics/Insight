/// <binding Clean='clean' />

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    browserify = require('gulp-browserify'),
    project = require("./project.json");

var paths = {
    webroot: "./" + project.webroot + "/",
    dest: {},
    source: {}
};

paths.source = {};
paths.source.js = "./app/**/*.js";
paths.source.css = "./app/content/**/.css";

paths.dest.js = paths.webroot + "js/**/*.js";
paths.dest.minJs = paths.webroot + "js/**/*.min.js";
paths.dest.css = paths.webroot + "css/**/*.css";
paths.dest.minCss = paths.webroot + "css/**/*.min.css";
paths.dest.concatJsDest = paths.webroot + "js/site.min.js";
paths.dest.concatCssDest = paths.webroot + "css/site.min.css";

gulp.task("clean:js", function (cb) {
    rimraf(paths.dest.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.dest.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task("min:js", function () {
    gulp.src([paths.dest.js, "!" + paths.dest.minJs], { base: "." })
        .pipe(concat(paths.dest.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
    gulp.src([paths.dest.css, "!" + paths.dest.minCss])
        .pipe(concat(paths.dest.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("min", ["min:js", "min:css"]);

gulp.task('app-build', [], function () {
    gulp.src("./app/app.js")
        .pipe(browserify({
            insertGlobals: true,
            debug: !gulp.env.production
        }))
        .pipe(gulp.dest(paths.webroot));
});